using CenterService.WebService.Enums;
using Microsoft.Extensions.Logging;
using Shared.DTOs;

namespace CenterService.Services
{
    public class ServerService
    {
        private readonly ILogger<ServerService> _logger;
        private readonly List<ServerDTO> _servers;
        public ServerService(ILogger<ServerService> logger)
        {
            _logger = logger;
            _servers = new List<ServerDTO>();
        }

        public bool AddServer(ServerDTO serverDTO)
        {
            if (_servers.Where(r=>r.Ip == serverDTO.Ip).Any())
                return false;

            _servers.Add(new ServerDTO
            {
                Ip = serverDTO.Ip,
                Name = serverDTO.Name,
                AllowedLevel = serverDTO.AllowedLevel,
                Id = Guid.NewGuid().ToString(),
                Online = 0,
                Port = serverDTO.Port,
                State = (int)ServerStateEnum.ONLINE
            });

            _logger.LogInformation("Starting server");
            return true;
        }

        public List<ServerDTO> GetServers()
        {
            return _servers;
        }
    }
}
