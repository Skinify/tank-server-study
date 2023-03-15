using Microsoft.EntityFrameworkCore;
using Tank.Enums;
using Tank.Models.Entities.Battle;
using Tank.Models.Entities.Battle.PVE;

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

        public static void SeedDifficultTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PVEDifficultyTypes>().HasData(
              new PVEDifficultyTypes { Id = (int)EPVEDifficultyTypes.Normal, Name = "Normal" }
              new PVEDifficultyTypes { Id = (int)EPVEDifficultyTypes.Nightmare, Name = "Nightmare" }
          );
        }
    }
}
