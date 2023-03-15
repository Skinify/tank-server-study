using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Quest
{
    [Table(nameof(CharacterQuests), Schema = "Quest")]
    public class CharacterQuests
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public ICollection<CharacterQuestContidionProgress> QuestConditionsProgress { get; set; } = null!;

        [ForeignKey(nameof(Quest))]
        public int QuestId { get; set; }
        public virtual Quests Quest { get; set; } = null!;
    }
}
