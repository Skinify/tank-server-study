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

RoadSettings? roadSettings = null;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IServer, Server>();

        services.AddDbContext<TankContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("Tank")),
            ServiceLifetime.Singleton
        );

        roadSettings = services.InjectSettings<RoadSettings>(context.Configuration);

        services.AddSingleton(opt =>
        {
            return new CancellationTokenSource();
        });        

        services.InjectTankRepositories();
        services.InjectSharedDTOMapping();
        services.InjectCenterClient(roadSettings.CenterWebServerUrl);
        services.AddSingleton<ClientWebSocket>();
        services.AddSingleton<FightConnector>();
        services.AddSingleton<BaseManagerCollection>();

        services.AddSingleton<IManager, ServerManager>();
        services.AddSingleton<ConnectedClientsManager>();

    })
    .UseSerilog((ctx, lc) =>
    {
        lc
            .Enrich.WithProperty("Workers", "Road")
            .Enrich.FromLogContext()
            .WriteTo.Console();

        if(roadSettings.Seq is not null)
            lc.WriteTo.Seq(roadSettings.Seq);

    })
    .Build();

host.Run();
