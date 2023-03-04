using Microsoft.EntityFrameworkCore;
using Tank.Models.Entities.Character;
using Tank.Models.Entities.Server;
using Tank.Models.Entities.Item;
using Tank.Seed;

namespace Tank
{
    public class TankContext : DbContext
    {
        public TankContext(DbContextOptions<TankContext> options)
                   : base(options)
        {
        }

        #region Character
        public DbSet<Cards> Cards { get; set; }
        public DbSet<Characters> Characters { get; set; }
        public DbSet<CharacterCards> CharacterCards { get; set; }
        public DbSet<CharacterRanks> CharacterRanks { get; set; }
        public DbSet<Levels> Levels { get; set; }
        public DbSet<CharactersFriends> CharactersFriends { get; set; }
        public DbSet<Ranks> Ranks { get; set; }
        #endregion

        #region Server
        public DbSet<ServerConfigs> ServerConfig { get; set; }
        public DbSet<Servers> Servers { get; set; }
        public DbSet<ServerStates> ServerStates { get; set; }
        #endregion

        #region Items
        public DbSet<ItemBindTypes> ItemBindTypes { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<ItemsCategories> ItemsCategory { get; set; }
        public DbSet<ItemHoleTypes> ItemHoleTypes { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedServerConfiguration();
            modelBuilder.SeedServers();
            modelBuilder.SeedItemsBindTypes();
            modelBuilder.SeedItemsCategory();
            modelBuilder.SeedItemsHoleTypes();
        }
    }
}
