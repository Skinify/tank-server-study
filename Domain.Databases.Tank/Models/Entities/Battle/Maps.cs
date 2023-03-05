using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Battle
{
    [Table(nameof(Maps), Schema = "Battle")]
    public class Maps
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ForePic { get; set; } = null!;
        public string? BackPic { get; set; } = null!;
        public string? Music { get; set; }
    }
}
