using Base.Interface;

namespace RoadWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServer _roadServer;

        public Worker(ILogger<Worker> logger, IServer server)
        {
            _logger = logger;
            _roadServer = server;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("Iniciando o RoadWorker");
                await _roadServer.Start();
                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(1000, stoppingToken);
                }
                await _roadServer.Stop(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao iniciar o RoadWorker");
            }
        }
    }
}