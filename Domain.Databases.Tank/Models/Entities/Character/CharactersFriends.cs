using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Character
{
    [Table(nameof(CharactersFriends), Schema = "Character")]
    [Index(nameof(CharacterId1), IsUnique = false)]
    [Index(nameof(CharacterId2), IsUnique = false)]
    [Keyless]
    public class CharactersFriends
    {
        public string CharacterId1 { get; set; } = null!;
        public string CharacterId2 { get; set; } = null!;
        public DateTime AddDate { get; set; }
    }
}
