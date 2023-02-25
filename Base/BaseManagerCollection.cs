using Base.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Base
{
    public class BaseManagerCollection
    {
        private readonly IServiceProvider _serviceProvider;

        public BaseManagerCollection(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public virtual async Task StartManagers()
        {
            var managers = _serviceProvider.GetServices<IManager>().ToList();
            foreach (IManager manager in managers)
            {
                await manager.Start();
            }
        }
    }
}