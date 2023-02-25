using Base;
using Base.Interface;
using Base.Packets.Client;
using CenterService.Config;
using CenterService.Enums;
using CenterService.Handlers;
using CenterService.Services;
using Microsoft.Extensions.Logging;

namespace CenterService
{
    public class Server : BaseServer<ClientPacketIn, ClientPacketOut>, IServer
    {
        private readonly ILogger<Server> _logger;
        private readonly CenterSettings _centerSettings;
        private readonly ServerService _serverService;

        public Server(ILogger<Server> logger, 
            IServiceProvider serviceProvider,
            CenterSettings centerSettings,
            ServerService serverService
            ) : base(serviceProvider, logger) {
            _logger = logger;
            _centerSettings = centerSettings;
            _serverService = serverService;

            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
        }

        public async Task Start()
        {
            _centerSettings.ValidateSettings();

            await _serverService.Start();

            RegisterHandlers(new Dictionary<int, Type>()
            {
                { (int)EPackageType.LOGIN, typeof(LoginHandler) }
            });

            ListenOn(_centerSettings.ServerIpAddress, _centerSettings.ServerPort);
            //await _centerWebService.ListenOn(_centerSettings.WebServerIpAddress, _centerSettings.WebServerPort);
        }

        public Task Stop(CancellationToken cancellationToken)
        {
            Stop();
            return Task.CompletedTask;
        }
    }
}