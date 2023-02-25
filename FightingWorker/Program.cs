using Base.Interface;
using FightingService;
using FightingService.Config;
using FightingWorker;
using Microsoft.EntityFrameworkCore;
using Shared.DI;
using Tank;
using Tank.DI;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IServer, Server>();

        services.AddDbContext<TankContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("Tank")),
            ServiceLifetime.Singleton
        );

        var settings = services.InjectSettings<FightSettings>(context.Configuration);

        services.InjectTankRepositories();
        services.InjectCenterClient(settings.CenterWebServerUrl);
    })
    .Build();

host.Run();
