using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Character
{
    [Table(nameof(Friends), Schema = "Character")]
    public class Friends
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Characters))]
        public int CharacterId { get; set; }
        public virtual Characters Character { get; set; } = null!;

        public bool IsBlocked { get; set; }

        public DateTime FriendshipStartDate { get; set; }
        public DateTime FriendshipEndDate { get; set; }
    }
}
