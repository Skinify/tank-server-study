using Tank.Repositories;
using Tank.Repositories._Interface;
using Microsoft.EntityFrameworkCore;

namespace Tank.Unity
{
    public class TankUnityOfWork
    {
        private readonly TankContext _tankContext;

        public TankUnityOfWork(TankContext tankContext) {
            _tankContext = tankContext;
            ConfigurationRepository = new ConfigurationRepository(tankContext);
            CharacterRepository = new CharacterRepository(tankContext);
            BattleRepository = new BattleRepository(tankContext);
            ItemRepository = new ItemRepository(tankContext);
        }

        public Task<int> Commit() {
            return _tankContext.SaveChangesAsync();
        }

        public void Rollback() {
            foreach (var entry in _tankContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        public IConfigurationRepository ConfigurationRepository { get; internal set; }
        public ICharacterRepository CharacterRepository { get; internal set; }
        public IBattleRepository BattleRepository { get; internal set; }
        public IItemRepository ItemRepository { get; internal set; }
    }
}
