using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using Base.GameSocket;
using Extensions;
using Helpers;
using Base.Interfaces;
using Base.Packets.Base;
using Base.Notations;
using System.Reflection;

namespace Base
{
    public class BaseServer<IN, OUT> where IN : BasePacketIn where OUT : BasePacketOut
    {
        private TcpListener _listener;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        protected readonly HybridDictionary _clients;

        private const string WEBSOCKET_DEFAULT_MAGIC_STRING = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";

        private AsyncCallback? _socketDataReceivedCallback;

        private readonly IList<Type> _handlersTypes;

        private readonly Timer _pingTimer;

        public BaseServer(IServiceProvider serviceProvider, ILogger logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _clients = new HybridDictionary();
            _socketDataReceivedCallback = OnDataReceived;
            _handlersTypes = new List<Type>();
            //_pingTimer = new Timer(new TimerCallback(PingClients), null, 1, 10000);
        }

        private void PingClients(object? state)
        {
            if (_clients.Count < 1)
                return;

            var clientsArray = new BaseClient<IN, OUT>[_clients.Count];

            _clients.Values.CopyTo(clientsArray, 0);
            clientsArray.ToList().ForEach(client =>
            {
                var t = MiscHelper.CreateInstance<OUT>()();
                t.WriteInt(1);
                t.WriteInt(999);
                client.SendData(t);
            });
        }

        public void ListenOn(IPAddress iP, int port)
        {
            _listener = new TcpListener(iP, port);
            _listener.Start();
            AcceptClient();
        }

        public void Stop()
        {
            lock (_clients.SyncRoot)
            {
                BaseClient<IN, OUT>[] list = new BaseClient<IN, OUT>[_clients.Keys.Count];
                _clients.Keys.CopyTo(list, 0);

                list.ToList().ForEach((client) => client.Disconnect());
            }

            _listener.Stop();
        }

        public void AcceptClient()
        {
            _listener.BeginAcceptTcpClient(new AsyncCallback(IncommingClientCallback), _listener);
        }

        private void WaitForData(object? state)
        {
            SocketState? socketState = state as SocketState;
            if (socketState is null)
                return;

            socketState.Socket.BeginReceive(socketState.Buffer, 0, socketState.Buffer.Length, SocketFlags.None, _socketDataReceivedCallback, socketState);
        }

        private void OnDataReceived(IAsyncResult async)
        {
            SocketState state = (SocketState)async.AsyncState;
            if (state == null || state.Socket == null || !state.Socket.Connected)
                return;

            int received = state.Socket.EndReceive(async);
            if (received == 0)
                return;

            var ip = state.Socket.GetClientIp();
            var clientIsAlreadyConnected = CheckClientIsAlreadyConnected(ip);

            state.ReceivedData.Append(Encoding.UTF8.GetString(state.Buffer, 0, received));
            string? clientMessage = state.ReceivedData.ToString();
            if (clientMessage.Contains("GET"))
            {
                //Cliente mandando handshake mesmo já estando conectado
                if (clientIsAlreadyConnected)
                    return;

                var webSocketKey = RetrieveSecWebSocketKey(clientMessage);
                if (string.IsNullOrEmpty(webSocketKey))
                    return;

                byte[] response = WriteHandShake(webSocketKey);
                state.Socket.Send(response);
                var client = AddClient(ip, new BaseClient<IN, OUT>(_serviceProvider, state));
                _handlersTypes.ToList().ForEach(handlerType => client.AddHandler(handlerType));
                client.Listen();
                
                client.Disconnected += RemoveClient;
            }

            state.Socket.EndReceive(async);
            AcceptClient();
        }

        private void IncommingClientCallback(IAsyncResult ar)
        {
            var listener = ar.AsyncState as TcpListener;
            if (listener is null)
                return;

            var tcpClient = listener.EndAcceptTcpClient(ar);

            WaitForData(new SocketState
            {
                Socket = tcpClient.Client
            });
        }

        public bool CheckClientIsAlreadyConnected(string ip)
        {
            lock (_clients.SyncRoot)
                return _clients.Contains(ip);
        }

        public BaseClient<IN, OUT> AddClient(string ip, BaseClient<IN, OUT> c)
        {
            lock (_clients.SyncRoot)
            {
                _clients.Add(ip, c);
            }
            return c;
        }

        public void RegisterHandlers(params Type[] types)
        {
            types.ToList().ForEach(_handlersTypes.Add);
        }

        public void RemoveClient(string ip, BaseClient<IN, OUT> c)
        {
            lock (_clients.SyncRoot)
                _clients.Remove(ip);

            c.Disconnected -= RemoveClient;
        }

        private static byte[] WriteHandShake(string webSocketKey)
        {
            var key = webSocketKey + WEBSOCKET_DEFAULT_MAGIC_STRING;
            byte[] encryptedKey = System.Security.Cryptography.SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(key));
            string base64EncryptedKey = Convert.ToBase64String(encryptedKey);
            return Encoding.UTF8.GetBytes(
                    "HTTP/1.1 101 Switching Protocols\r\n" +
                    "Connection: Upgrade\r\n" +
                    "Upgrade: websocket\r\n" +
                    "Sec-WebSocket-Accept: " + base64EncryptedKey + "\r\n\r\n");
        }

        private static string RetrieveSecWebSocketKey(string message)
        {
            return Regex.Match(message, "Sec-WebSocket-Key: (.*)").Groups[1].Value.Trim();
        }
    }
}