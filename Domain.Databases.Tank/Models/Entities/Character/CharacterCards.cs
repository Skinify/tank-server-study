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

        [ForeignKey(nameof(Cards))]
        public int CardId { get; set; }
        public int Place { get; set; }
        public int Level { get; set; }
    }
}
