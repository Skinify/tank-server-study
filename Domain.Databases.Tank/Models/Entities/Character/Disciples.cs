using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Character
{
    [Table(nameof(Disciples), Schema = "Character")]
    public class Disciples
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Characters))]
        public int CharacterId { get; set; }
        public virtual Characters Character { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime RelationshipStartTime { get; set; }
        public DateTime? RelationshipStartEnd { get; set; }
    }
}
