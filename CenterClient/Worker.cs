using Base.Interface;

namespace CenterWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServer _centerService;

        public Worker(ILogger<Worker> logger, IServer centerService)
        {
            _logger = logger;
            _centerService = centerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("Iniciando o CenterWorker");
                await _centerService.Start();
                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(1000, stoppingToken);
                }
                await _centerService.Stop(stoppingToken);
            }
            catch(Exception ex) { 
                _logger.LogError(ex, "Erro ao iniciar o CenterWorker");
            }
        }
    }
}