using Tank.Models.Entities.Server;

namespace Tank.Repositories._Interface
{
    public interface IServerRepository
    {
        Task<IList<Servers>> GetServerList();
        Task<ServerConfigs?> GetServerConfigById(int configId);
        Task<ServerConfigs?> GetServerConfigByName(string configName);
        Task<IList<ServerConfigs>> GetServerConfigs();
    }
}
