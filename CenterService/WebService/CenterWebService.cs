using CenterService.Services;
using Microsoft.Extensions.Logging;
using Shared.DTOs;
using System.Net;

namespace CenterService.WebService
{
    public class CenterWebService
    {
        private readonly ServerService _serverService;
        private readonly ILogger<CenterWebService> _logger;

        public CenterWebService(ILogger<CenterWebService> logger, ServerService serverService)
        {
            _serverService = serverService;
            _logger = logger;            
        }

        public async Task<int> AASGetState()
        {
            return await _serverService.GetAAS();
        }

        public Task<bool> AASUpdateState(bool state)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActivePlayer(bool isActive)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChargeMoney(int userID, string chargeID)
        {
            throw new NotImplementedException();
        }

        public Task ConnectOn(IPAddress address, int port)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreatePlayer(int id, string name, string password, bool isFirst)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExperienceRateUpdate(int serverId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetConfigState(int type)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServerDTO>> GetServerList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> KitoffUser(int playerID, string msg)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MailNotice(int playerID)
        {
            throw new NotImplementedException();
        }

        public Task<int> NoticeServerUpdate(int serverId, int type)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Reload(string type)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReLoadServerList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SystemNotice(string msg)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateConfigState(int type, bool state)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> ValidateLoginAndGetID(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}
