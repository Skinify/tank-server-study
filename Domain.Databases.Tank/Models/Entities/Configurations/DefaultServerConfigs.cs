using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Configurations
{
    [Table(nameof(DefaultServerConfigs), Schema = "Configurations")]
    public class DefaultServerConfigs
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null;
        public string Value { get; set; } = null!;
    }
}
