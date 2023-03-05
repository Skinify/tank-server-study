using API.DTOs.Response;
using API.Services._Interface;
using AutoMapper;
using Tank.Enums;
using Tank.Models.Entities.Item;
using Tank.Unity;

namespace API.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IMapper _mapper;
        private readonly TankUnityOfWork _tankUnityOfWork;

        public ItemsService(IMapper mapper, TankUnityOfWork tankUnityOfWork) {
            _mapper = mapper;
            _tankUnityOfWork = tankUnityOfWork;
        }
        public async Task<IList<ItemsCategoriesDTO>> ListAllItemsCategories()
        {
            var items = await _tankUnityOfWork.ItemRepository.SelectAllItemsCategories();
            return _mapper.Map<IList<ItemsCategoriesTypes>, IList<ItemsCategoriesDTO>>(items);
        }

        public async Task<IList<ShopCategoriesDTO>> ListAllShopCategories()
        {
            var categories = await  _tankUnityOfWork.ItemRepository.SelectAllShopCategories();
            return _mapper.Map<IList<ShopCategoriesTypes>, IList<ShopCategoriesDTO>>(categories);
        }

        public async Task<IList<ShopItemDTO>> ListShopItemsFromCategory(EShopCategoriesTypes eShopCategoriesTypes)
        {
            var categories = await _tankUnityOfWork.ItemRepository.SelectShopItemsFromCategory(eShopCategoriesTypes);
            categories = categories.Where(r => r.IsActive).ToList();
            return _mapper.Map<IList<ShopItems>, IList<ShopItemDTO>>(categories);
        }
    }
}
