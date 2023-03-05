using Microsoft.EntityFrameworkCore;
using Tank.Enums;
using Tank.Models.Entities.Item;
using Tank.Repositories._Interface;

namespace Tank.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly TankContext _tankContext;
        public ItemRepository(TankContext tankContext)
        {
            _tankContext = tankContext;
        }

        public Task<List<ItemsCategoriesTypes>> SelectAllItemsCategories()
        {
            return _tankContext.ItemsCategory.ToListAsync();
        }

        public Task<List<ShopCategoriesTypes>> SelectAllShopCategories()
        {
            return _tankContext.ShopCategoriesTypes.ToListAsync();
        }

        public Task<List<ShopItems>> SelectShopItemsFromCategory(EShopCategoriesTypes eShopCategoriesTypes)
        {
            return _tankContext.ShopItems.Where(r => (int)eShopCategoriesTypes == r.ShopCategoryId)
                .Join(_tankContext.Items, 
                    shopItems => shopItems.ItemId,
                    items => items.Id,
                    (shopItem, item) => new ShopItems(shopItem)
                    {
                        Item = item
                    }
                )
                .ToListAsync();
        }
    }
}
