using Microsoft.EntityFrameworkCore;
using Tank.Models.Entities.Battle;
using Tank.Models.Entities.Configurations;

namespace Tank.Seed
{
    public static partial class Seed
    {
        public static void SeedRoomTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StageTypes>().HasData(
              new StageTypes { Id = 0, Description = "Server offline", Name = "Match" },
              new StageTypes { Id = 0, Description = "Server offline", Name = "Freedom" },
              new StageTypes { Id = 0, Description = "Server offline", Name = "Exploration" },
              new StageTypes { Id = 0, Description = "Server offline", Name = "Boss" },
              new StageTypes { Id = 0, Description = "Server offline", Name = "Treasure" }
          );
        }
    }
}
