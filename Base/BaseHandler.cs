using Base.Interfaces;

namespace Base
{
    public class BaseHandler
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly string _socketId;
        protected readonly Action<IPacket> _sendData;

        public BaseHandler(IServiceProvider serviceProvider, string socketId, Action<IPacket> sendData)
        {
            _serviceProvider = serviceProvider;
            _socketId = socketId;
            _sendData = sendData;
        }
    }
}
