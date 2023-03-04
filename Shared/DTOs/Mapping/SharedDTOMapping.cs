using AutoMapper;
using CenterWorker;
using Shared.DTOs.Internal;

namespace API.DTOs.Mapping
{
    public class SharedDTOMapping : Profile
    {
        public SharedDTOMapping() {
            CreateMap<ListServerResponse, ServerDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ServerId))
                .ForMember(d => d.State, opt => opt.MapFrom(s => s.ServerState))
                .ForMember(d => d.Ip, opt => opt.MapFrom(s => s.ServerIp))
                .ForMember(d => d.Online, opt => opt.MapFrom(s => s.PlayersOnline))
                .ForMember(d => d.AllowedLevel, opt => opt.MapFrom(s => s.AllowedLevel))
                .ForMember(d => d.MaxPlayers, opt => opt.MapFrom(s => s.MaxPlayers))
                .ReverseMap();

            CreateMap<AddServerRequest, ServerDTO>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Ip, opt => opt.MapFrom(s => s.ServerIp))
                .ForMember(d => d.AllowedLevel, opt => opt.MapFrom(s => s.AllowedLevel))
                .ForMember(d => d.MaxPlayers, opt => opt.MapFrom(s => s.MaxPlayers))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.ServerName))
                .ReverseMap();
        }
    }
}
