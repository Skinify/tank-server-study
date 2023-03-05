using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tank.Models.Entities.Item;

namespace Tank.Models.Entities.Character
{
    [Index(nameof(CharacterId), IsUnique = true)]
    [Index(nameof(ItemId), IsUnique = true)]
    [Table(nameof(CharacterItems), Schema = "Character")]
    public class CharacterItems
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Characters))]
        public int CharacterId { get; set; }
        public virtual Characters Character { get; set; } = null!;

        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        public virtual Items Item { get; set; } = null!;

        [Description("Quantity of that item")]
        public int Count { get; set; }

        [Description("Color of the item")]
        public string? Color { get; set; } = null;

        [Description("Strengthen level")]
        public int Strengthen { get; set; }

        public int AttackCompose { get; set; }
        public int DefenseCompose { get; set; }
        public int AgilityCompose { get; set; }
        public int LuckCompose { get; set; }

        public bool IsBindable { get; set; }
        public bool IsUsed { get; set; }

        public bool IsPermanent { get; set; }
        public int? DurationDate { get; set; }

        public DateTime AcquisitionDate { get; set; }
        public DateTime? DateOfUse { get; set; }

        public int Hole1Xp { get; set; }
        public int Hole2Xp { get; set; }
        public int Hole3Xp { get; set; }
        public int Hole4Xp { get; set; }
        public int Hole5Xp { get; set; }
        public int Hole6Xp { get; set; }

        public bool IsHidden { get; set; }
    }
}
