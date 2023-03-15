using Microsoft.EntityFrameworkCore;
using Tank.Enums;
using Tank.Models.Entities.Quest;

namespace Tank.Seed
{
    public static partial class Seed
    {
        public static ModelBuilder SeedQuestTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestConditionTypes>().HasData(
                new QuestConditionTypes { Id = (int)EQuestConditionType.AccountInfo, Name = "Bind 0" },
                new QuestConditionTypes { Id = (int)EQuestConditionType.ItemMounting, Name = "Bind 0" },
                new QuestConditionTypes { Id = (int)EQuestConditionType.ItemFusion, Name = "Bind 0" },
                new QuestConditionTypes { Id = (int)EQuestConditionType.ItemMelt, Name = "Bind 0" }
            );

            return modelBuilder;
        }
    }
}
