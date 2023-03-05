using Microsoft.EntityFrameworkCore;
using Tank.Models.Entities.Character;
using Tank.Models.Entities.Battle;
using Tank.Models.Entities.Item;
using Tank.Seed;
using Tank.Models.Entities.Battle.PVE;
using Tank.Models.Entities.Battle.PVP;
using Tank.Models.Entities.Configurations;

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
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Ranks> Ranks { get; set; }
        public DbSet<Marriages> Marriages { get; set; }
        public DbSet<MarriageProposals> MarriageProposals { get; set; }
        public DbSet<Disciples> Disciples { get; set; }
        #endregion

        #region Battle
        public DbSet<DefaultServerConfigs> ServerConfig { get; set; }

        #region PVE
        public DbSet<NPCs> NPCs { get; set; }
        public DbSet<PVEDifficultyTypes> PVEDifficultyTypes { get; set; }
        public DbSet<PVEGames> PVEGames { get; set; }
        public DbSet<PVEStages> PVEStages { get; set; }
        #endregion

        #region PVP
        public DbSet<PVPGames> PVPGames { get; set; }
        public DbSet<PVPStages> PVPStages { get; set; }
        #endregion

        public DbSet<Maps> Maps { get; set; }
        public DbSet<Spaws> Spaws { get; set; }
        public DbSet<StageTypes> StageTypes { get; set; }
        #endregion

        #region Items
        public DbSet<ItemBindTypes> ItemBindTypes { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<ItemsCategoriesTypes> ItemsCategory { get; set; }
        public DbSet<ItemHoleTypes> ItemHoleTypes { get; set; }
        public DbSet<ShopItems> ShopItems { get; set; }
        public DbSet<ShopCategoriesTypes> ShopCategoriesTypes { get; set; }
        #endregion

        #region Configurations
        public DbSet<DefaultServerConfigs> DefaultServerConfigs { get; set; }
        public DbSet<DefaultServerRates> DefaultServerRates { get; set; }
        public DbSet<RateTypes> RateTypes { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedServerConfiguration();
            modelBuilder.SeedItemsBindTypes();
            modelBuilder.SeedItemsCategory();
            modelBuilder.SeedItemsHoleTypes();
            modelBuilder.SeedShopCategoryTypes();
            modelBuilder.SeedLevels();
            modelBuilder.SeedRanks();
        }
    }
}
