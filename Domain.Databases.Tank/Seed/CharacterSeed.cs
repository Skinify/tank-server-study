using Microsoft.EntityFrameworkCore;
using Tank.Enums;
using Tank.Models.Entities.Character;
using Tank.Models.Entities.Item;

namespace Tank.Seed
{
    public static partial class Seed
    {
        public static void SeedLevels(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Levels>().HasData(
                new Levels { Level = 1, Xp = 0, Blood = 1000 },
                new Levels { Level = 2, Xp = 37, Blood = 1050 },
                new Levels { Level = 3, Xp = 162, Blood = 1100 },
                new Levels { Level = 4, Xp = 505, Blood = 1150 },
                new Levels { Level = 5, Xp = 1283, Blood = 1200 },
                new Levels { Level = 6, Xp = 2801, Blood = 1250 },
                new Levels { Level = 7, Xp = 5462, Blood = 1300 },
                new Levels { Level = 8, Xp = 9771, Blood = 1350 },
                new Levels { Level = 9, Xp = 16341, Blood = 1400 },
                new Levels { Level = 10, Xp = 25899, Blood = 1450 },
                new Levels { Level = 11, Xp = 39291, Blood = 1530 },
                new Levels { Level = 12, Xp = 57489, Blood = 1610 },
                new Levels { Level = 13, Xp = 81594, Blood = 1690 },
                new Levels { Level = 14, Xp = 112847, Blood = 1770 },
                new Levels { Level = 15, Xp = 152630, Blood = 1850 },
                new Levels { Level = 16, Xp = 202472, Blood = 1970 },
                new Levels { Level = 17, Xp = 264058, Blood = 2090 },
                new Levels { Level = 18, Xp = 339232, Blood = 2210 },
                new Levels { Level = 19, Xp = 430003, Blood = 2330 },
                new Levels { Level = 20, Xp = 538554, Blood = 2450 },
                new Levels { Level = 21, Xp = 667242, Blood = 2620 },
                new Levels { Level = 22, Xp = 818609, Blood = 2790 },
                new Levels { Level = 23, Xp = 995383, Blood = 2960 },
                new Levels { Level = 24, Xp = 1200489, Blood = 3130 },
                new Levels { Level = 25, Xp = 1437053, Blood = 3300 },
                new Levels { Level = 26, Xp = 1753103, Blood = 3380 },
                new Levels { Level = 27, Xp = 2112735, Blood = 3460 },
                new Levels { Level = 28, Xp = 2519637, Blood = 3540 },
                new Levels { Level = 29, Xp = 2977665, Blood = 3620 },
                new Levels { Level = 30, Xp = 3490849, Blood = 3700 },
                new Levels { Level = 31, Xp = 4145185, Blood = 3870 },
                new Levels { Level = 32, Xp = 4873978, Blood = 4040 },
                new Levels { Level = 33, Xp = 5684269, Blood = 4210 },
                new Levels { Level = 34, Xp = 6583537, Blood = 4380 },
                new Levels { Level = 35, Xp = 7579710, Blood = 4550 },
                new Levels { Level = 36, Xp = 8681174, Blood = 4670 },
                new Levels { Level = 37, Xp = 9896788, Blood = 4790 },
                new Levels { Level = 38, Xp = 11235892, Blood = 4910 },
                new Levels { Level = 39, Xp = 12708322, Blood = 5030 },
                new Levels { Level = 40, Xp = 14324419, Blood = 5150 },
                new Levels { Level = 41, Xp = 16263735, Blood = 5200 },
                new Levels { Level = 42, Xp = 18590915, Blood = 5250 },
                new Levels { Level = 43, Xp = 21383531, Blood = 5300 },
                new Levels { Level = 44, Xp = 24734669, Blood = 5350 },
                new Levels { Level = 45, Xp = 28756036, Blood = 5400 },
                new Levels { Level = 46, Xp = 33581676, Blood = 5450 },
                new Levels { Level = 47, Xp = 39372443, Blood = 5500 },
                new Levels { Level = 48, Xp = 46321365, Blood = 5550 },
                new Levels { Level = 49, Xp = 54660070, Blood = 5600 },
                new Levels { Level = 50, Xp = 63832646, Blood = 5650 },
                new Levels { Level = 51, Xp = 73922480, Blood = 5680 },
                new Levels { Level = 52, Xp = 85021297, Blood = 5710 },
                new Levels { Level = 53, Xp = 97229996, Blood = 5740 },
                new Levels { Level = 54, Xp = 110659565, Blood = 5770 },
                new Levels { Level = 55, Xp = 125432090, Blood = 5800 },
                new Levels { Level = 56, Xp = 140943242, Blood = 5830 },
                new Levels { Level = 57, Xp = 157229951, Blood = 5860 },
                new Levels { Level = 58, Xp = 174330996, Blood = 5890 },
                new Levels { Level = 59, Xp = 192287093, Blood = 5920 },
                new Levels { Level = 60, Xp = 211140995, Blood = 5950 }
            );
        }
        public static void SeedRanks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ranks>().HasData(
                new Ranks { Id = 1, Name = "Novato", Attack = 0, Defense = 0, Agility = 0, Luck = 0, Hp = 0, Damage = 0, Guard = 0}
            );
        }
    }
}
