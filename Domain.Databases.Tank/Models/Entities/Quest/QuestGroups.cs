using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Quest
{
    [Table(nameof(QuestGroups), Schema = "Quest")]
    public class QuestGroups
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Quests> Quests { get; set; } = null!;

        public bool IsRepeatable { get; set; }
        public int? MaxRepeatTimes { get; set; }
    }
}
