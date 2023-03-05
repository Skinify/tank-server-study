using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Item
{
    [Table(nameof(ShopItems), Schema = "Item")]
    [Keyless]
    public class ShopItems
    {
        public ShopItems() { }
        public ShopItems(ShopItems shopItems)
        {
            ItemId = shopItems.ItemId;
            Item = shopItems.Item;
            ShopCategoryId = shopItems.ShopCategoryId;
            ShopCategory = shopItems.ShopCategory;
            AddDate = shopItems.AddDate;
            IsActive = shopItems.IsActive;
            IsLimitedOffer = shopItems.IsLimitedOffer;
            IsPromotion = shopItems.IsPromotion;
            IsLimitedOffer = shopItems.IsLimitedOffer;
            IsNew = shopItems.IsNew;
        }

        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        public virtual Items Item { get; set; } = null!;


        [ForeignKey(nameof(ShopCategoriesTypes))]
        public int ShopCategoryId { get; set; }
        public virtual ShopCategoriesTypes ShopCategory { get; set; } = null!;

        public DateTime AddDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsLimitedOffer { get; set; }
        public bool IsPromotion { get; set; }
        public bool IsPopular { get; set; }
        public bool IsNew { get; set; }
    }
}
