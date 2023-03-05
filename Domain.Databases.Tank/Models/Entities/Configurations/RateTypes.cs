using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Configurations
{
    [Table(nameof(RateTypes), Schema = "Configurations")]
    public class RateTypes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null;
    }
}
