using CenterService.Services;
using Grpc.Core;
using Shared.DTOs;

#pragma warning disable CS0436 // Conflitos de tipo com o tipo importado no Shared

namespace CenterWorker.Endpoints
{
    public class WebService : CenterEndpoint.CenterEndpointBase
    {
        private readonly ILogger<WebService> _logger;
        private readonly ServerService _testService;

        public WebService(ILogger<WebService> logger, ServerService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        public override Task<AddServerResponse> AddServer(AddServerRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AddServerResponse
            {
                Registered = _testService.AddServer(new ServerDTO
                {
                    Ip = request.ServerIp,
                    AllowedLevel = request.AllowedLevel,
                    Name = request.ServerName,
                })
            });
        }

        public override async Task ListServers(ListServerRequest request, IServerStreamWriter<ListServerResponse> responseStream, ServerCallContext context)
        {
            foreach (ServerDTO serv in _testService.GetServers())
            {
                await responseStream.WriteAsync(new ListServerResponse
                {
                    ServerIp = serv.Ip,
                    ServerId = Guid.NewGuid().ToString(),
                    PlayersOnline = serv.Online,
                    AllowedLevel = serv.AllowedLevel,
                    ServerState = serv.State,
                });
            }
        }
    }
}