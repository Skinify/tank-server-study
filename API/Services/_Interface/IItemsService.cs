using API.DTOs.Response;
using Tank.Enums;

namespace API.Services._Interface
{
    public interface IItemsService
    {
        public Task<IList<ItemsCategoriesDTO>> ListAllItemsCategories();
        public Task<IList<ShopCategoriesDTO>> ListAllShopCategories();
        public Task<IList<ShopItemDTO>> ListShopItemsFromCategory(EShopCategoriesTypes eShopCategoriesTypes);
    }
}
