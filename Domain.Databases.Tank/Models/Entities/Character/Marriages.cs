using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Character
{
    [Table(nameof(Marriages), Schema = "Character")]
    [Index(nameof(PartnerId), IsUnique = false)]
    public class Marriages
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Characters))]
        public int PartnerId { get; set; }
        public virtual Characters Partner { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime WeddingDate { get; set; }
        public DateTime? DivorceDate { get; set; }
    }
}
