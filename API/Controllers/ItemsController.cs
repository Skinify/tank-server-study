using API.DTOs.Response;
using API.Services._Interface;
using Microsoft.AspNetCore.Mvc;
using Tank.Enums;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : Controller
    {
        private readonly IItemsService _shopService;

        public ItemsController(IItemsService shopService) {
            _shopService = shopService;
        }

        [Route("ItemsCategories")]
        [HttpGet]
        public async Task<ActionResult<IList<ItemsCategoriesDTO>>> ItemsCategories()
        {
            return Ok(await _shopService.ListAllItemsCategories());
        }

        [Route("ShopCategories")]
        [HttpGet]
        public async Task<ActionResult<IList<ShopCategoriesDTO>>> ShopCategories()
        {
            return Ok(await _shopService.ListAllShopCategories());
        }

        [Route("ShopItemsFromCategory")]
        [HttpGet]
        public async Task<ActionResult<IList<ItemsCategoriesDTO>>> ItemsCategories(EShopCategoriesTypes eShopCategoriesTypes)
        {
            return Ok(await _shopService.ListShopItemsFromCategory(eShopCategoriesTypes));
        }


        //Teste
        [Route("CharItemsByBagType")]
        [HttpGet]
        public async Task<ActionResult<IList<ItemsCategoriesDTO>>> CharItemsByBagType(EBagTypes eBagTypes)
        {
            return Ok(await _shopService.ListCharacterItemsByBagType(eBagTypes));
        }

    }
}
