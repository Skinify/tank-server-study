using Microsoft.EntityFrameworkCore;
using Tank.Models.Entities.Configurations;
using Tank.Repositories._Interface;

namespace Tank.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly TankContext _tankContext;
        public ConfigurationRepository(TankContext tankContext)
        {
            _tankContext = tankContext;
        }

        public async Task<DefaultServerConfigs?> GetServerConfigById(int configId)
        {
            return await _tankContext.ServerConfig.FirstOrDefaultAsync(r => r.Id == configId);
        }

        public async Task<DefaultServerConfigs?> GetServerConfigByName(string configName)
        {
            return await _tankContext.ServerConfig.FirstOrDefaultAsync(r => r.Name == configName);
        }

        public async Task<IList<DefaultServerConfigs>> GetServerConfigs()
        {
            return await _tankContext.ServerConfig.ToListAsync();
        }
    }
}
