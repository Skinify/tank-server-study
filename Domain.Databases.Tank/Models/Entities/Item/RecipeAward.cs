using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Item
{
    [Table(nameof(RecipeAward), Schema = "Item")]
    public class RecipeAward
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        public virtual Items Item { get; set; } = null!;


        public int Count { get; set; }

        public int Strengthen { get; set; }

        public int AttackCompose { get; set; }
        public int DefenseCompose { get; set; }
        public int AgilityCompose { get; set; }
        public int LuckCompose { get; set; }

        public bool IsBinded { get; set; }
    }
}
