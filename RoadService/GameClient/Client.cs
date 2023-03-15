using Base.Interfaces;

namespace RoadService.GameClient
{
    public class Client
    {
        private readonly Action<IPacket> _sendData;
        public string SocketId { get; private set; }
        public int UserId { get; private set; }

        public Client(string socketId, int userId, Action<IPacket> sendData) {
            _sendData = sendData;
            SocketId = socketId;
            UserId = userId;
        }
    }
}
