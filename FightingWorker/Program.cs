using Base.Interface;
using FightingService;
using FightingService.Config;
using FightingWorker;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.DI;
using Tank;
using Tank.DI;

FightSettings? fightSettings = null;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IServer, Server>();

        services.AddDbContext<TankContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("Tank")),
            ServiceLifetime.Singleton
        );

        fightSettings = services.InjectSettings<FightSettings>(context.Configuration);

        services.InjectTankRepositories();
        services.InjectSharedDTOMapping();
        services.InjectCenterClient(fightSettings.CenterWebServerUrl);
    })
    .UseSerilog((ctx, lc) =>
    {
        lc
            .Enrich.WithProperty("Workers", "Road")
            .Enrich.FromLogContext()
            .WriteTo.Console();

        if (fightSettings.Seq is not null)
            lc.WriteTo.Seq(fightSettings.Seq);

    })
    .Build();

host.Run();
