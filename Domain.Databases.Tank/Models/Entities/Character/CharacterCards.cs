using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Character
{
    [Index(nameof(CharacterId), IsUnique = true)]
    [Table(nameof(CharacterCards), Schema = "Character")]
    [Keyless]
    public class CharacterCards
    {
        [ForeignKey(nameof(Characters))]
        public int CharacterId { get; set; }
        public virtual Characters Character { get; set; } = null!;


        [ForeignKey(nameof(Cards))]
        public int CardId { get; set; }
        public virtual Cards Card { get; set; } = null!;


        public int Place { get; set; }
        public int Level { get; set; }
    }
}
