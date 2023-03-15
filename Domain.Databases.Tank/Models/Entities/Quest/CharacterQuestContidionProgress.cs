using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Quest
{
    [Table(nameof(CharacterQuestContidionProgress), Schema = "Quest")]
    public class CharacterQuestContidionProgress
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(QuestConditionTypes))]
        public int QuestConditionTypeId { get; set; }
        public virtual QuestConditionTypes QuestConditionType { get; set; } = null!;


        [ForeignKey(nameof(CharacterQuests))]
        public int CharacterQuestsId { get; set; }
        public virtual CharacterQuests CharacterQuest { get; set; } = null!;
    }
}
