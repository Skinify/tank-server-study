using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Item
{
    [Table(nameof(ItemRecipes), Schema = "Item")]
    public class ItemRecipes
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        public virtual Items Item { get; set; } = null!;

        [ForeignKey(nameof(Recipes))]
        public int RecipeId { get; set; }
        public virtual Recipes Recipe { get; set; } = null!;
    }
}
