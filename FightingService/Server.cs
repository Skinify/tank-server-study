using Base;
using Base.Interface;
using Base.Packets.Server;
using FightingService.Config;
using FightingService.Handlers;
using Microsoft.Extensions.Logging;

namespace FightingService
{
    public class Server : BaseServer<ServerPacketIn, ServerPacketOut>, IServer
    {
        private readonly ILogger<Server> _logger;
        private readonly FightSettings _fightSettings;

        public Server(ILogger<Server> logger,
            IServiceProvider serviceProvider,
            FightSettings centerSettings
            ) : base(serviceProvider, logger)
        {
            _logger = logger;
            _fightSettings = centerSettings;

            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
        }

        public async Task Start()
        {
            _fightSettings.ValidateSettings();

            ListenOn(_fightSettings.ServerIpAddress, _fightSettings.ServerPort);
        }

        public Task Stop(CancellationToken cancellationToken)
        {
            Stop();
            return Task.CompletedTask;
        }
    }
}