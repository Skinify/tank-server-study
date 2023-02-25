using Base.Interfaces;
using Shared.DTOs;
using Tank.Enums;
using Tank.Repositories._Interface;

namespace CenterService.Services
{
    public class ServerService : IManager
    {
        private readonly IServerRepository _serverRepository;
        private readonly IDictionary<int, ServerDTO> _servers;

        public ServerService(IServerRepository serverRepository) {
            _serverRepository = serverRepository;
            _servers = new Dictionary<int, ServerDTO>();
        }

        public Task<int> GetAAS()
        {
            return Task.FromResult(10);
        }

        public List<ServerDTO> GetServerList()
        {
            return _servers.Values.ToList();
        }

        public async Task Start()
        {
            var servers = await _serverRepository.GetServerList();
            servers.ToList().ForEach(server =>
            {
                _servers.Add(server.Id, new ServerDTO
                {
                    Id= server.Id,
                    Ip = server.Ip,
                    AllowedLevel = server.AllowedLevel,
                    Name = server.Name,
                    State = (int)EServerState.ONLINE,
                });
            });
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}
