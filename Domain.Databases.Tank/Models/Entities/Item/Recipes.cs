using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Item
{
    [Table(nameof(Recipes), Schema = "Item")]
    public class Recipes
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(RecipeTypes))]
        public int RecipeTypesId { get; set; }
        public virtual RecipeTypes RecipeType { get; set; } = null!;

        [ForeignKey(nameof(RecipeAward))]
        public int RecipeAwardId { get; set; }
        public virtual RecipeAward Award { get; set; } = null!;

        public ICollection<ItemRecipes> ItemRecipes { get; set; } = null!;

        public float SuccessRate { get; set; }
    }
}
