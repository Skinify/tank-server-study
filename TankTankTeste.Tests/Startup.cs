using Microsoft.Extensions.DependencyInjection;
using Tank.Repositories._Interface;
using Tank.Repositories._Mocked;

namespace TankTankTeste.Tests
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICharacterRepository, MockedCharacterRepository>();
        }
    }
}
