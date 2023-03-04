using API.DTOs.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Internal;
using Shared.ServerClients;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayController : ControllerBase
    {
        private readonly ILogger<PlayController> _logger;
        private readonly CenterClient _centerClient;
        private readonly IMapper _mapper;

        public PlayController(ILogger<PlayController> logger, CenterClient centerClient, IMapper mapper)
        {
            _logger = logger;
            _centerClient = centerClient;
            _mapper = mapper;
        }

        [Route("Play")]
        [HttpPost]
        public async Task<ActionResult<LoginResponseDTO>> Play()
        {
            return Ok();
        }

        [Route("ListServers")]
        [HttpGet]
        public async Task<ActionResult<IList<ListServersResponseDTO>>> ListServers()
        {
            var serverList = await _centerClient.ListServers();
            return Ok(_mapper.Map<IList<ServerDTO>, IList<ListServersResponseDTO>>(serverList));
        }
    }
}