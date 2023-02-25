using Base;
using Base.Interface;
using Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using RoadService;
using RoadService.Config;
using RoadService.Connectors;
using RoadService.Managers;
using RoadWorker;
using Serilog;
using Shared.DI;
using System.Net.WebSockets;
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

        var settings = services.InjectSettings<RoadSettings>(context.Configuration);

        services.AddSingleton(opt =>
        {
            return new CancellationTokenSource();
        });        

        services.InjectTankRepositories();
        services.InjectCenterClient(settings.CenterWebServerUrl);
        services.AddSingleton<ClientWebSocket>();
        services.AddSingleton<FightConnector>();
        services.AddSingleton<BaseManagerCollection>();

        services.AddSingleton<IManager, ServerManager>();

    })
    .UseSerilog((ctx, lc) =>
    {
        lc
            .Enrich.WithProperty("Workers", "Road")
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341/");

    })
    .Build();

host.Run();
