using CenterWorker.Services;
using Grpc.Core;

namespace CenterWorker.Endpoints
{
    public class WebService : CenterEndpoint.CenterEndpointBase
    {
        private readonly ILogger<WebService> _logger;
        private readonly TestService _testService;

        public WebService(ILogger<WebService> logger, TestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        public override Task<AddServerResponse> AddServer(AddServerRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AddServerResponse
            {
                Registered = _testService.AddServer(request.ServerIp)
            });
        }

        public override async Task ListServers(ListServerRequest request, IServerStreamWriter<ListServerResponse> responseStream, ServerCallContext context)
        {
            foreach (string serv in _testService.GetServers())
            {
                await responseStream.WriteAsync(new ListServerResponse
                {
                    ServerIp = serv
                });
            }
        }
    }
}