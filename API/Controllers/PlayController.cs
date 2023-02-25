using API.DTOs.Response;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using static CenterWorker.CenterEndpoint;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayController : ControllerBase
    {
        private readonly ILogger<PlayController> _logger;
        private readonly CenterEndpointClient _centerClient;

        public PlayController(ILogger<PlayController> logger, CenterEndpointClient centerClient)
        {
            _logger = logger;
            _centerClient = centerClient;
        }

        [HttpPost(Name = "Play")]
        public async Task<ActionResult<LoginResponseDTO>> Play()
        {
            return Ok();
        }

        [HttpGet(Name = "ListServers")]
        public async Task<ActionResult<IList<ListServersResponseDTO>>> ListServers()
        {
            var serverList = new List<string>();
            using(var call = _centerClient.ListServers(new CenterWorker.ListServerRequest()))
            {
                while(await call.ResponseStream.MoveNext())
                {
                    serverList.Add(call.ResponseStream.Current.ServerIp);
                }
            }
            return Ok(serverList);
        }
    }
}