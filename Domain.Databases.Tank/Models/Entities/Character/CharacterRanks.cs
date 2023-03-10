using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Character
{
    [Index(nameof(CharacterId), IsUnique = false)]
    [Index(nameof(RankId), IsUnique = true)]
    [Table(nameof(CharacterRanks), Schema = "Character")]
    [Keyless]
    public class CharacterRanks
    {
        [ForeignKey(nameof(Characters))]
        public int CharacterId { get; set; }
        public virtual Characters Character { get; set; } = null!;

        [ForeignKey(nameof(Ranks))]
        public int RankId { get; set; }
        public virtual Ranks Rank { get; set; } = null!;

        public DateTime AcquisitionDate { get; set; }
    }
}
