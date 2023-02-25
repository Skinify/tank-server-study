using Base.Config;
using Base.Interfaces;
using Tank.Unity;

namespace RoadService.Managers
{
    public class ServerManager: IManager
    {
        private readonly TankUnityOfWork _tankUnityOfWork;

        public ServerManager(TankUnityOfWork tankUnityOfWork) {
            _tankUnityOfWork = tankUnityOfWork;
        }

        public async Task Start()
        {
            var configs = await _tankUnityOfWork.ServerRepository.GetServerConfigs();
            GameProperties.InitializeGameProperties(configs.ToDictionary(r => r.Name, r => (object)r.Value));
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}
