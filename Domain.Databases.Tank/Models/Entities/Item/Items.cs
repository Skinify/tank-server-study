using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Item
{
    [Table(nameof(Item), Schema = "Item")]
    public class Items
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        public string? Remark { get; set; }


        [ForeignKey(nameof(ItemsCategories))]
        public int ItemsCategoryId { get; set; }

        [Required]
        public string Icon { get; set; } = null!;

        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Agility { get; set; }
        public int Luck { get; set; }
        public int Hp { get; set; }
        public int Damage { get; set; }
        public int Guard { get; set; }

        public bool? Gender { get; set; }

        public int? MinLevel { get; set; }

        public bool IsStrengthenable { get; set; }
        public bool IsComposable { get; set; }
        public bool IsDroppable { get; set; }
        public bool IsEquipable { get; set; }
        public bool IsUsable { get; set; }

        [ForeignKey(nameof(ItemBindTypes))]
        public int? ItemBindTypeId { get; set; }

        [ForeignKey(nameof(ItemHoleTypes))]
        public int? Hole1Id { get; set; }

        [ForeignKey(nameof(ItemHoleTypes))]
        public int? Hole2Id { get; set; }

        [ForeignKey(nameof(ItemHoleTypes))]
        public int? Hole3Id { get; set; }

        [ForeignKey(nameof(ItemHoleTypes))]
        public int? Hole4Id { get; set; }

        [ForeignKey(nameof(ItemHoleTypes))]
        public int? Hole5Id { get; set; }

        [ForeignKey(nameof(ItemHoleTypes))]
        public int? Hole6Id { get; set; }
    }
}
