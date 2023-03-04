using AutoMapper;
using CenterService.Services;
using Grpc.Core;
using Shared.DTOs.Internal;

#pragma warning disable CS0436 // Conflitos de tipo com o tipo importado no Shared

namespace CenterWorker.Endpoints
{
    public class WebService : CenterEndpoint.CenterEndpointBase
    {
        private readonly ILogger<WebService> _logger;
        private readonly ServerService _testService;
        private readonly IMapper _mapper;

        public WebService(ILogger<WebService> logger, ServerService testService, IMapper mapper)
        {
            _logger = logger;
            _testService = testService;
            _mapper = mapper;
        }

        public override Task<AddServerResponse> AddServer(AddServerRequest request, ServerCallContext context)
        {
            //var @out = _mapper.Map<AddServerRequest, ServerDTO>(request);
            return Task.FromResult(new AddServerResponse
            {
                Registered = _testService.AddServer(new ServerDTO
                {
                    AllowedLevel = request.AllowedLevel,
                    Ip = request.ServerIp,
                    MaxPlayers = request.MaxPlayers,
                    Name = request.ServerName
                })
            });
        }

        public override async Task ListServers(ListServerRequest request, IServerStreamWriter<ListServerResponse> responseStream, ServerCallContext context)
        {
            foreach (ServerDTO serv in _testService.GetServers())
            {
                await responseStream.WriteAsync(_mapper.Map<ServerDTO, ListServerResponse>(serv));
            }
        }
    }
}