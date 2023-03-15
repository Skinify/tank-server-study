using Base;
using Base.Interface;
using Base.Packets.Client;
using Microsoft.Extensions.Logging;
using RoadService.Config;
using RoadService.Connectors;
using RoadService.Handlers.Client;
using RoadService.Handlers.Server;
using Shared.ServerClients;

namespace RoadService
{
    public class Server : BaseServer<ClientPacketIn, ClientPacketOut>, IServer
    {
        private readonly ILogger<Server> _logger;
        private readonly RoadSettings _roadSettings;
        private readonly CenterClient _centerClient;
        private readonly FightConnector _fightConnector;
        private readonly BaseManagerCollection _managersCollection;

        public Server(
            ILogger<Server> logger, 
            RoadSettings roadSettings, 
            IServiceProvider serviceProvider,
            CenterClient centerClient,
            FightConnector fightConnector,
            BaseManagerCollection baseManagerCollection
            ) : base(serviceProvider, logger)
        {
            _logger = logger;
            _roadSettings = roadSettings;
            _centerClient = centerClient;
            _fightConnector = fightConnector;
            _managersCollection = baseManagerCollection;

            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
        }

        public async Task Start()
        {
            _roadSettings.ValidateSettings();

            await _managersCollection.StartManagers();

            //Connecting to fight servers and adding server communication handlers
            _fightConnector.AddHandler(typeof(ServerPackageTestHandler));
            await _fightConnector.ConnectTo($"ws://{_roadSettings.FightServerIp}:{_roadSettings.FightServerPort}/");

            //Register client handlers
            RegisterHandlers(typeof(LoginHandler));

            //Listening for clients
            ListenOn(_roadSettings.ServerIpAddress, _roadSettings.ServerPort);

            var reply = await _centerClient.AddServer(new Shared.DTOs.Internal.ServerDTO
            {
                Ip = _roadSettings.ServerIp,
                Port = _roadSettings.ServerPort,
                Name = _roadSettings.ServerName,
                AllowedLevel = _roadSettings.AllowedLevel,
                MaxPlayers = _roadSettings.MaxPlayers,
            });

            if (!reply.Registered)
                Stop();
        }

        public Task Stop(CancellationToken cancellationToken)
        {
            Stop();
            return Task.CompletedTask;
        }
    }
}