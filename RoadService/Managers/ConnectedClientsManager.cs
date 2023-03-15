using Base.Interfaces;
using RoadService.GameClient;
using Tank.Unity;

namespace RoadService.Managers
{
    public class ConnectedClientsManager : IManager
    {
        private readonly TankUnityOfWork _tankUnityOfWork;
        private readonly IDictionary<string, Client> _users;

        public ConnectedClientsManager(TankUnityOfWork tankUnityOfWork) {
            _tankUnityOfWork = tankUnityOfWork;
            _users = new Dictionary<string, Client>();
        }

        public void AddClient(Client client)
        {
            _users.Add(client.SocketId, client);
        }

        public bool CheckClientIsConnected(string clientId)
        {
            return _users.ContainsKey(clientId);
        }

        public async Task Start()
        {
    
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}
