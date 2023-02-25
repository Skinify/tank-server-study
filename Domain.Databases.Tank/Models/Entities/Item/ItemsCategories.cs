using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Item
{
    [Table(nameof(ItemsCategories), Schema = "Item")]
    public class ItemsCategories
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Description("Name of the category")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = null!;

        [Description("Place that itens of that category should take when equiped")]
        public int? Place { get; set; }

        public string? Remark { get; set; } = null;
    }
}
