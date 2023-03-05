using API.DTOs.Response;
using AutoMapper;
using Shared.DTOs.Internal;
using Tank.Models.Entities.Item;

namespace API.DTOs.Mapping
{
    public class DTOMapping : Profile
    {
        public DTOMapping() {
            CreateMap<ServerDTO, ListServersResponseDTO>()
                .ForMember(d => d.Ip, opt => opt.MapFrom(s => s.Ip))
                .ForMember(d => d.Port, opt => opt.MapFrom(s => s.Port));

            CreateMap<ItemsCategoriesTypes, ItemsCategoriesDTO>();
            CreateMap<ShopCategoriesTypes, ShopCategoriesDTO>();
            CreateMap<ShopItems, ShopItemDTO>()
                .ForMember(d => d.Item, opt => opt.MapFrom(s => s.Item));
        }
    }
}
