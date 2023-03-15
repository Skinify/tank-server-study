using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Item
{
    [Table(nameof(Items), Schema = "Item")]
    public class Items
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        public string? Remark { get; set; }


        [ForeignKey(nameof(ItemsCategoriesTypes))]
        public int ItemsCategoryId { get; set; }
        public virtual ItemsCategoriesTypes ItemsCategory { get; set; } = null!;


        [ForeignKey(nameof(BagTypes))]
        public int BagTypesId { get; set; }
        public virtual BagTypes BagType { get; set; } = null!;


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
        public int ItemBindTypeId { get; set; }
        public virtual ItemBindTypes ItemBindType { get; set; } = null!;


        [ForeignKey(nameof(ItemHoleTypes))]
        public int? Hole1Id { get; set; }
        public virtual ItemHoleTypes? Hole1 { get; set; }


        [ForeignKey(nameof(ItemHoleTypes))]
        public int? Hole2Id { get; set; }
        public virtual ItemHoleTypes? Hole2 { get; set; }


        [ForeignKey(nameof(ItemHoleTypes))]
        public int? Hole3Id { get; set; }
        public virtual ItemHoleTypes? Hole3 { get; set; }



        [ForeignKey(nameof(ItemHoleTypes))]
        public int? Hole4Id { get; set; }
        public virtual ItemHoleTypes? Hole4 { get; set; }


        [ForeignKey(nameof(ItemHoleTypes))]
        public int? Hole5Id { get; set; }
        public virtual ItemHoleTypes? Hole5 { get; set; }


        [ForeignKey(nameof(ItemHoleTypes))]
        public int? Hole6Id { get; set; }
        public virtual ItemHoleTypes? Hole6 { get; set; }

        public ICollection<ItemRecipes> ItemRecipes { get; set; } = null!;
    }
}
