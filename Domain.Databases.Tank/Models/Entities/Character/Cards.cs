using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tank.Models.Entities.Item;

namespace Tank.Models.Entities.Character
{
    [Table(nameof(Cards), Schema = "Character")]
    public class Cards
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } = null!;

        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        public virtual Items Item { get; set; } = null!;
    }
}
