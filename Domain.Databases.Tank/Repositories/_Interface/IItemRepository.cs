using Tank.Enums;
using Tank.Models.Entities.Item;

namespace Tank.Repositories._Interface
{
    public interface IItemRepository
    {
        Task<List<ItemsCategoriesTypes>> SelectAllItemsCategories();
        Task<List<ShopCategoriesTypes>> SelectAllShopCategories();
        Task<List<ShopItems>> SelectShopItemsFromCategory(EShopCategoriesTypes eShopCategoriesTypes);
    }
}
