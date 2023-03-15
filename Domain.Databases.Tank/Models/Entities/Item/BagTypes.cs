using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Item
{
    [Table(nameof(BagTypes), Schema = "Item")]
    public class BagTypes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
