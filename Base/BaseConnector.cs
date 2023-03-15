using Base.Interfaces;
using Base.Notations;
using Base.Packets.Server;
using Helpers;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Reflection;

namespace Base
{
    //Facilitar conexoes server to server
    public class BaseConnector
    {
        private readonly ClientWebSocket _clientWebSocket;
        private readonly IServiceProvider _serviceProvider;
        private readonly CancellationToken _cancellationToken;

        private readonly BlockingCollection<byte[]> _recvQueue;
        private readonly BlockingCollection<IPacket> _sendQueue;

        private readonly Dictionary<int, IHandler<IPacket>> _packageHandlers;

        private readonly string _clientId;

        public BaseConnector(ClientWebSocket clientWebSocket, IServiceProvider serviceProvider, CancellationTokenSource cancellationToken)
        {
            _clientWebSocket = clientWebSocket;
            _serviceProvider = serviceProvider;
            _cancellationToken = cancellationToken.Token;
            _recvQueue = new BlockingCollection<byte[]>();
            _sendQueue = new BlockingCollection<IPacket>();
            _packageHandlers = new Dictionary<int, IHandler<IPacket>>();

            _clientId = Guid.NewGuid().ToString();
        }

        public async Task ConnectTo(string serverUrl)
        {
            await _clientWebSocket.ConnectAsync(new Uri(serverUrl), _cancellationToken);
            try
            {
                var sendTask = Task.Run(() => Send(_clientWebSocket, _cancellationToken));
                var recvTask = Task.Run(() => Recv(_clientWebSocket, _cancellationToken));

                new Thread(async () =>
                {
                    do
                    {
                        var package = new ServerPacketIn();
                        byte[] recvMsg = _recvQueue.Take();
                        byte[] decodedMessage = SocketHelper.GetDecodedData(recvMsg, recvMsg.Length);
                        package.Fill(decodedMessage, decodedMessage.Length);
                        var packageType = package.ReadInt(true);
                        if (_packageHandlers.TryGetValue(packageType, out IHandler<IPacket>? handler))
                        {
                            IPacket? packetOut = await handler.Handle(package);
                            if (packetOut is not null)
                                _sendQueue.Add(packetOut);
                        }

                    } while (_clientWebSocket.State == WebSocketState.Open);
                }).Start();
            }
            catch (Exception)
            {
                await _clientWebSocket.CloseAsync(WebSocketCloseStatus.Empty, null, _cancellationToken);
            }
        }

        private async Task Recv(ClientWebSocket ws, CancellationToken token)
        {
            Console.WriteLine("Recv task started...");
            var buffer = new byte[1024];
            WebSocketReceiveResult taskResult;

            while (ws.State == WebSocketState.Open)
            {
                do
                {
                    taskResult = await ws.ReceiveAsync(buffer, token);
                    _recvQueue.Add(buffer, token);
                } while (!taskResult.EndOfMessage);
            }
            Console.WriteLine("Recv task exiting...");
        }

        private async Task Send(ClientWebSocket ws, CancellationToken token)
        {
            Console.WriteLine("Send task started...");
            do
            {
                IPacket sendMsg = _sendQueue.Take();
                var toSend = SocketHelper.FrameMessage(sendMsg.Buffer);
                await ws.SendAsync(toSend, WebSocketMessageType.Binary, true, token);

            } while (ws.State == WebSocketState.Open);

            Console.WriteLine("Send task exiting...");
        }

        public void SendData(IPacket packet)
        {
            _sendQueue.Add(packet);
        }

        public void AddHandler(params Type[] types)
        {
            types.ToList().ForEach((type) =>
            {
                Action<IPacket> sendData = SendData;
                IHandler<IPacket>? handlerInstance = Activator.CreateInstance(type, _serviceProvider, _clientId, sendData) as IHandler<IPacket>;
                if (handlerInstance is null)
                    return;

                PacketHandler? handlerAnotation = handlerInstance.GetType().GetCustomAttribute(typeof(PacketHandler), true) as PacketHandler;
                if (handlerAnotation is null)
                    throw new Exception($"Handler {type.Name} is not associated with any package type");

                if (!typeof(IHandler<ServerPacketOut>).IsAssignableFrom(type))
                    throw new Exception($"Handler {type.Name} - {handlerAnotation.HandlerCode}, does not implement IHandler");

                if (!_packageHandlers.TryAdd(handlerAnotation.HandlerCode, handlerInstance))
                    throw new Exception($"Handler of code {handlerAnotation.HandlerCode} has already been added");
            });
        }
    }
}
