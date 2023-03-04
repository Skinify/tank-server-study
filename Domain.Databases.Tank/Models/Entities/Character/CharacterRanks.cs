using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Character
{
    [Index(nameof(CharacterId), IsUnique = true)]
    [Index(nameof(RankId), IsUnique = true)]
    [Table(nameof(CharacterRanks), Schema = "Character")]
    [Keyless]
    public class CharacterRanks
    {
        [ForeignKey("Character")]
        public int CharacterId { get; set; }

        [ForeignKey("Ranks")]
        public int RankId { get; set; }

        public DateTime AcquisitionDate { get; set; }
    }
}
