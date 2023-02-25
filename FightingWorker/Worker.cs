using Base.Interface;

namespace FightingWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServer _fightServer;

        public Worker(ILogger<Worker> logger, IServer server)
        {
            _logger = logger;
            _fightServer = server;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _fightServer.Start();
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
            await _fightServer.Stop(stoppingToken);
        }
    }
}