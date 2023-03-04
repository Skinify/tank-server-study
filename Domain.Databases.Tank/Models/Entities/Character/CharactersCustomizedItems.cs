using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Tank.Models.Entities.Item;

namespace Tank.Models.Entities.Character
{
    [Table(nameof(CharactersCustomizedItems), Schema = "Character")]
    [Index(nameof(CharacterId), IsUnique = false)]
    [Keyless]
    public class CharactersCustomizedItems
    {
        [ForeignKey(nameof(Characters))]
        public int CharacterId { get; set; }
        public virtual Characters Character { get; set; } = null!;


        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        public virtual Items Item { get; set; } = null!;

        public string? Color { get; set; }
        public bool IsHidden { get; set; }
    }
}
