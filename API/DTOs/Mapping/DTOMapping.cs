using API.DTOs.Response;
using AutoMapper;
using Shared.DTOs.Internal;

namespace API.DTOs.Mapping
{
    public class DTOMapping : Profile
    {
        public DTOMapping() {
            CreateMap<ServerDTO, ListServersResponseDTO>()
                .ForMember(d => d.Ip, opt => opt.MapFrom(s => s.Ip))
                .ForMember(d => d.Port, opt => opt.MapFrom(s => s.Port));
        }
    }
}
