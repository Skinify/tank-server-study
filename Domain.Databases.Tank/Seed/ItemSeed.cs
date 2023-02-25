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

        public static void SeedItemsCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemsCategories>().HasData(
                new ItemsCategories { Id = 1, Name = "Chapéu", Place = 1 },
                new ItemsCategories { Id = 2, Name = "Óculos", Place = 2 },
                new ItemsCategories { Id = 3, Name = "Cabelo", Place = 3 },
                new ItemsCategories { Id = 4, Name = "Face", Place = 4 },
                new ItemsCategories { Id = 5, Name = "Roupa", Place = 5 },
                new ItemsCategories { Id = 6, Name = "Olhos", Place = 6 },
                new ItemsCategories { Id = 7, Name = "Arma", Place = 7 },
                new ItemsCategories { Id = 8, Name = "Pulseiras", Place = 8 },
                new ItemsCategories { Id = 9, Name = "Anéis", Place = 9 },
                new ItemsCategories { Id = 10, Name = "Itens de combate" },
                new ItemsCategories { Id = 11, Name = "Itens de auxílio" },
                new ItemsCategories { Id = 12, Name = "Itens de Tarefa" },
                new ItemsCategories { Id = 13, Name = "Terno", Place = 11 },
                new ItemsCategories { Id = 14, Name = "Colar", Place = 12 },
                new ItemsCategories { Id = 15, Name = "Decoração", Place = 13 },
                new ItemsCategories { Id = 16, Name = "Bolha", Place = 14 },
                new ItemsCategories { Id = 17, Name = "Itens auxiliares", Place = 15 },
                new ItemsCategories { Id = 18, Name = "Baú de Cartões" },
                new ItemsCategories { Id = 19, Name = "Ajuda", Place = 16 },
                new ItemsCategories { Id = 20, Name = "Poção de Prática" },
                new ItemsCategories { Id = 23, Name = "Inventário de Missões Práticas" },
                new ItemsCategories { Id = 25, Name = "Baú de Cartões" },
                new ItemsCategories { Id = 27, Name = "Armas especiais", Place = 27 },
                new ItemsCategories { Id = 30, Name = "Propriedade especial" },
                new ItemsCategories { Id = 31, Name = "Mão Secundária Especial" },
                new ItemsCategories { Id = 32, Name = "Sementes" },
                new ItemsCategories { Id = 33, Name = "Fertilizante" },
                new ItemsCategories { Id = 34, Name = "Alimento de mascote" },
                new ItemsCategories { Id = 35, Name = "Ovo mascote" },
                new ItemsCategories { Id = 36, Name = "Colheita" },
                new ItemsCategories { Id = 50, Name = "Arma mascote" },
                new ItemsCategories { Id = 51, Name = "Chapéu mascote" }
            );
        }
    }
}
