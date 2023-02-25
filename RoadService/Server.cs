using Base;
using Base.Interface;
using Base.Packets.Client;
using Microsoft.Extensions.Logging;
using RoadService.Config;
using RoadService.Connectors;
using RoadService.Handlers.Client;
using RoadService.Handlers.Server;
using static CenterWorker.CenterEndpoint;

namespace RoadService
{
    public class Server : BaseServer<ClientPacketIn, ClientPacketOut>, IServer
    {
        private readonly ILogger<Server> _logger;
        private readonly RoadSettings _roadSettings;
        private readonly CenterEndpointClient _centerClient;
        private readonly FightConnector _fightConnector;
        private readonly BaseManagerCollection _managersCollection;

        public Server(
            ILogger<Server> logger, 
            RoadSettings roadSettings, 
            IServiceProvider serviceProvider,
            CenterEndpointClient centerClient,
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
            _fightConnector.AddHandler(1, typeof(ServerPackageTestHandler));
            await _fightConnector.ConnectTo($"ws://{_roadSettings.FightServerIp}:{_roadSettings.FightServerPort}/");

            //Register client handlers
            RegisterHandlers(new Dictionary<int, Type>()
            {
                { 1, typeof(ClientPackageTestHandler) }
            });

            //Listening for clients
            ListenOn(_roadSettings.ServerIpAddress, _roadSettings.ServerPort);


            var reply = await _centerClient.AddServerAsync(new CenterWorker.AddServerRequest
            {
                ServerIp = $"{_roadSettings.ServerIpAddress}:{_roadSettings.ServerPort}"
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