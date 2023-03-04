using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Item
{
    [Table(nameof(ItemHoleTypes), Schema = "Item")]
    public class ItemHoleTypes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public int OpenCost { get; set; }
    }
}
