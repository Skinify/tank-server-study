using Microsoft.Extensions.DependencyInjection;
using Tank.Repositories;
using Tank.Repositories._Interface;
using Tank.Unity;

namespace Tank.DI
{
    public static partial class Inject
    {
        public static void InjectTankRepositories(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSingleton<IConfigurationRepository, ConfigurationRepository>();
            serviceDescriptors.AddSingleton<ICharacterRepository, CharacterRepository>();

            serviceDescriptors.AddSingleton<TankUnityOfWork>();
        }
    }
}
