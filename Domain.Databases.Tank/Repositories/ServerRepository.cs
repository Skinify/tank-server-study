using Microsoft.EntityFrameworkCore;
using Tank.Models.Entities.Server;
using Tank.Repositories._Interface;

namespace Tank.Repositories
{
    public class ServerRepository : IServerRepository
    {
        private readonly TankContext _tankContext;
        public ServerRepository(TankContext tankContext)
        {
            _tankContext = tankContext;
        }

        public async Task<ServerConfigs?> GetServerConfigById(int configId)
        {
            return await _tankContext.ServerConfig.FirstOrDefaultAsync(r => r.Id == configId);
        }

        public async Task<ServerConfigs?> GetServerConfigByName(string configName)
        {
            return await _tankContext.ServerConfig.FirstOrDefaultAsync(r => r.Name == configName);
        }

        public async Task<IList<ServerConfigs>> GetServerConfigs()
        {
            return await _tankContext.ServerConfig.ToListAsync();
        }

        public async Task<IList<Servers>> GetServerList()
        {
            return new List<Servers>();
        }
    }
}
