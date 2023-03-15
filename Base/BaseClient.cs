using Base.GameSocket;
using Base.Interfaces;
using Extensions;
using System.Net.Sockets;
using Helpers;
using Base.Packets.Base;
using Base.Notations;
using System.Reflection;

namespace Base
{
    public class BaseClient<IN, OUT> where IN : BasePacketIn where OUT : BasePacketOut
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly SocketState _clientSocketState;
        private readonly Dictionary<int, IHandler<OUT>> _packageHandlers;
        private AsyncCallback? _socketDataReceivedCallback;
        private readonly string _socketId;

        public delegate void ClientEventHandle(string clientIp, BaseClient<IN, OUT> C);
        public event ClientEventHandle? Disconnected;

        public BaseClient(IServiceProvider serviceProvider, SocketState socketState)
        {
            _serviceProvider = serviceProvider;
            _clientSocketState = socketState;
            _packageHandlers = new Dictionary<int, IHandler<OUT>>();
            _socketId = Guid.NewGuid().ToString();
        }

        public void Listen()
        {
            WaitForData(_clientSocketState);
        }

        private void WaitForData(object? state)
        {
            SocketState? socketState = state as SocketState;
            if (socketState is null)
                return;

            socketState.Clear();

            if (_socketDataReceivedCallback is null)
                _socketDataReceivedCallback = OnDataReceived;

            if (socketState.Socket.IsSocketConnected())
                socketState.Socket.BeginReceive(socketState.Buffer, 0, socketState.Buffer.Length, SocketFlags.None, _socketDataReceivedCallback, socketState);
            else
                Disconnect();
        }

        private void OnDataReceived(IAsyncResult async)
        {
            try
            {
                SocketState state = (SocketState)async.AsyncState;

                var byteComming = state.ReadBufferDataAsByteArray();

                var packageIn = MiscHelper.CreateInstance<IN>()();
                if (packageIn is null)
                    return;

                packageIn.Fill(byteComming, byteComming.Length);

                //Ler primeiro inteiro que simboliza o tipo do pacote
                var packageType = packageIn.ReadInt();

                if (_packageHandlers.TryGetValue(packageType, out IHandler<OUT>? handler))
                {
                    Task.Run(async () =>
                    {
                        try
                        {
                            IPacket? packageOut = await handler.Handle(packageIn);
                            if (packageOut is not null)
                                SendData(packageOut);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    });
                }
            }
            catch (Exception) { }

            WaitForData(async.AsyncState);
        }

        public void AddHandler(params Type[] types)
        {
            types.ToList().ForEach((type) =>
            {
                Action<IPacket> sendData = SendData;
                IHandler<OUT>? handlerInstance = Activator.CreateInstance(type, _serviceProvider, _socketId, sendData) as IHandler<OUT>;
                if (handlerInstance is null)
                    return;

                PacketHandler? handlerAnotation = handlerInstance.GetType().GetCustomAttribute(typeof(PacketHandler), true) as PacketHandler;
                if (handlerAnotation is null)
                    throw new Exception($"Handler {type.Name} is not associated with any package type");

                if (!typeof(IHandler<OUT>).IsAssignableFrom(type))
                    throw new Exception($"Handler {type.Name} - {handlerAnotation.HandlerCode}, does not implement IHandler");

                if (!_packageHandlers.TryAdd(handlerAnotation.HandlerCode, handlerInstance))
                    throw new Exception($"Handler of code {handlerAnotation.HandlerCode} has already been added");
            });
        }

        public void Disconnect()
        {
            if (this._clientSocketState.Socket is null)
                return;

            Disconnected?.Invoke(_clientSocketState.Socket.RemoteEndPoint.ToString(), this);
            this._clientSocketState.Dispose();
        }

        public void SendData(IPacket packet)
        {
            var packageOut = MiscHelper.CreateInstance<OUT>()();
            if (packageOut is null)
                return;

            packageOut.Fill(packet.Buffer, packet.Buffer.Length);

            var toSend = SocketHelper.FrameMessage(packageOut.Buffer);

            this._clientSocketState.Socket?.BeginSend(toSend, 0, toSend.Length, SocketFlags.None, null, _clientSocketState);
        }
    }
}
