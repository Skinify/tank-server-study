using Tank.Models.Entities.Configurations;

namespace Tank.Repositories._Interface
{
    public interface IBattleRepository
    {
        Task<DefaultServerConfigs?> GetServerConfigById(int configId);
        Task<DefaultServerConfigs?> GetServerConfigByName(string configName);
        Task<IList<DefaultServerConfigs>> GetServerConfigs();
    }
}
