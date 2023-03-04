using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Character
{
    [Index(nameof(CharacterTeacherId), IsUnique = false)]
    [Table(nameof(CharacterTeachers), Schema = "Character")]
    [Keyless]
    public class CharacterTeachers
    {
        [ForeignKey(nameof(Characters))]
        public int CharacterTeacherId;
        public virtual Characters CharacterTeacher { get; set; } = null!;

        public ICollection<Characters> Students { get; set; } = null!;

        public DateTime RelationshipStartTime { get; set; }
        public DateTime? RelationshipStartEnd { get; set; }
    }
}
