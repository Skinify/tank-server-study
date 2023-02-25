using Base.Config;
using Base.Interfaces;
using CenterService.Enums;

namespace CenterService.Services
{
    public class GlobalTimersService : IManager
    {
        private readonly AuctionService _auctionService;
        private readonly IDictionary<EGlobalTimer, Timer> _timers;
        public GlobalTimersService(AuctionService auctionService) {
            _auctionService = auctionService;
            _timers = new Dictionary<EGlobalTimer, Timer>();
        }

        public Task Start()
        {
            _timers.Add(
                EGlobalTimer.AUCTION,
                new Timer(new TimerCallback(async (sender) => await _auctionService.ScanAuction()), null, GameProperties.ScanAuctionInterval, GameProperties.ScanAuctionInterval)
            );

            return Task.CompletedTask;
        }

        public Task Stop()
        {
            _timers.ToList().ForEach(timer =>
            {
                timer.Value.Dispose();
            });
            _timers.Clear();

            return Task.CompletedTask;
        }
    }
}
