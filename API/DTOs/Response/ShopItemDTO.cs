using Tank.Models.Entities.Item;

namespace API.DTOs.Response
{
    public class ShopItemDTO
    {
        public Items Item { get; set; } = null!;
        public bool IsActive { get; set; }
        public bool IsLimitedOffer { get; set; }
        public bool IsPromotion { get; set; }
        public bool IsPopular { get; set; }
        public bool IsNew { get; set; }
    }
}
