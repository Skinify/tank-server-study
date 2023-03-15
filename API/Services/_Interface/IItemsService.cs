using API.DTOs.Response;
using Tank.Enums;
using Tank.Models.Entities.Character;

namespace API.Services._Interface
{
    public interface IItemsService
    {
        public Task<IList<ItemsCategoriesDTO>> ListAllItemsCategories();
        public Task<IList<ShopCategoriesDTO>> ListAllShopCategories();
        public Task<IList<ShopItemDTO>> ListShopItemsFromCategory(EShopCategoriesTypes eShopCategoriesTypes);
        public Task<IList<CharacterItems>> ListCharacterItemsByBagType(EBagTypes eBagTypes);
    }
}
