using AutoMapper;
using CenterWorker;
using Grpc.Core;
using Shared.DTOs.Internal;
using static CenterWorker.CenterEndpoint;

namespace Shared.ServerClients
{
    public class CenterClient
    {
        private readonly CenterEndpointClient _client;
        private readonly IMapper _mapper;

        public CenterClient(CenterEndpointClient centerClient, IMapper mapper) {
            _client = centerClient;
            _mapper = mapper;
        }

        public async Task<IList<ServerDTO>> ListServers()
        {            
            var serverList = new List<ListServerResponse>();
            using (var call = _client.ListServers(new ListServerRequest()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    serverList.Add(call.ResponseStream.Current);
                }
            }
            return _mapper.Map<IList<ListServerResponse>, IList<ServerDTO>>(serverList);
        }

        public async Task<AddedServerDTO> AddServer(ServerDTO serverDTO)
        {
            var reply = await _client.AddServerAsync(new CenterWorker.AddServerRequest
            {
                ServerIp = $"{serverDTO.Ip}:{serverDTO.Port}",
                ServerName = serverDTO.Name,
                AllowedLevel = serverDTO.AllowedLevel,
            });

            return new AddedServerDTO
            {
                Registered = reply.Registered
            };
        }
    }
}
