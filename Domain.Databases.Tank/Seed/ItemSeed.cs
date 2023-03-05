using Microsoft.EntityFrameworkCore;
using Tank.Enums;
using Tank.Models.Entities.Item;

namespace Tank.Seed
{
    public static partial class Seed
    {
        public static void SeedItemsBindTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemBindTypes>().HasData(
                new ItemBindTypes { Id = (int)EItemBindType.Bind0, Name = "Bind 0" },
                new ItemBindTypes { Id = (int)EItemBindType.Bind1, Name = "Bind 1" },
                new ItemBindTypes { Id = (int)EItemBindType.Bind2, Name = "Bind 2" }
            );
        }

        public static void SeedItemsHoleTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemHoleTypes>().HasData(
                new ItemHoleTypes { Id = (int)EItemHoleType.ATTACK, Description = "Hole for attacking purpose" },
                new ItemHoleTypes { Id = (int)EItemHoleType.DEFENSE, Description = "Hole for defending purpose" },
                new ItemHoleTypes { Id = (int)EItemHoleType.ATTRIBUTE, Description = "Hole for increase attributes purpose" }
            );
        }

        public static void SeedShopCategoryTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopCategoriesTypes>().HasData(
                new ShopCategoriesTypes { Id = (int)EShopCategoriesTypes.BATTLE, Name= "Battle itens", Description = "Battle itens" },
                new ShopCategoriesTypes { Id = (int)EShopCategoriesTypes.DRESS, Name = "Dressing itens", Description = "Dressing itens" },
                new ShopCategoriesTypes { Id = (int)EShopCategoriesTypes.PROPS, Name = "Props itens", Description = "Props itens" },
                new ShopCategoriesTypes { Id = (int)EShopCategoriesTypes.EXCHANGE, Name = "Exchange itens", Description = "Exchange itens" },
                new ShopCategoriesTypes { Id = (int)EShopCategoriesTypes.FREE, Name = "Free itens", Description = "Free itens" }
            );
        }

        public static void SeedItemsCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemsCategoriesTypes>().HasData(
                new ItemsCategoriesTypes { Id = 1, Name = "Chapéu", Place = 1 },
                new ItemsCategoriesTypes { Id = 2, Name = "Óculos", Place = 2 },
                new ItemsCategoriesTypes { Id = 3, Name = "Cabelo", Place = 3 },
                new ItemsCategoriesTypes { Id = 4, Name = "Face", Place = 4 },
                new ItemsCategoriesTypes { Id = 5, Name = "Roupa", Place = 5 },
                new ItemsCategoriesTypes { Id = 6, Name = "Olhos", Place = 6 },
                new ItemsCategoriesTypes { Id = 7, Name = "Arma", Place = 7 },
                new ItemsCategoriesTypes { Id = 8, Name = "Pulseiras", Place = 8 },
                new ItemsCategoriesTypes { Id = 9, Name = "Anéis", Place = 9 },
                new ItemsCategoriesTypes { Id = 10, Name = "Itens de combate" },
                new ItemsCategoriesTypes { Id = 11, Name = "Itens de auxílio" },
                new ItemsCategoriesTypes { Id = 12, Name = "Itens de Tarefa" },
                new ItemsCategoriesTypes { Id = 13, Name = "Terno", Place = 11 },
                new ItemsCategoriesTypes { Id = 14, Name = "Colar", Place = 12 },
                new ItemsCategoriesTypes { Id = 15, Name = "Decoração", Place = 13 },
                new ItemsCategoriesTypes { Id = 16, Name = "Bolha", Place = 14 },
                new ItemsCategoriesTypes { Id = 17, Name = "Itens auxiliares", Place = 15 },
                new ItemsCategoriesTypes { Id = 18, Name = "Baú de Cartões" },
                new ItemsCategoriesTypes { Id = 19, Name = "Ajuda", Place = 16 },
                new ItemsCategoriesTypes { Id = 20, Name = "Poção de Prática" },
                new ItemsCategoriesTypes { Id = 23, Name = "Inventário de Missões Práticas" },
                new ItemsCategoriesTypes { Id = 25, Name = "Baú de Cartões" },
                new ItemsCategoriesTypes { Id = 27, Name = "Armas especiais", Place = 27 },
                new ItemsCategoriesTypes { Id = 30, Name = "Propriedade especial" },
                new ItemsCategoriesTypes { Id = 31, Name = "Mão Secundária Especial" },
                new ItemsCategoriesTypes { Id = 32, Name = "Sementes" },
                new ItemsCategoriesTypes { Id = 33, Name = "Fertilizante" },
                new ItemsCategoriesTypes { Id = 34, Name = "Alimento de mascote" },
                new ItemsCategoriesTypes { Id = 35, Name = "Ovo mascote" },
                new ItemsCategoriesTypes { Id = 36, Name = "Colheita" },
                new ItemsCategoriesTypes { Id = 50, Name = "Arma mascote" },
                new ItemsCategoriesTypes { Id = 51, Name = "Chapéu mascote" }
            );
        }
    }
}
