using Base.Interface;
using CenterService;
using CenterService.Config;
using CenterService.Services;
using CenterService.WebService;
using CenterWorker;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.WebServices.Contracts.Server;
using SoapCore;
using Tank.DI;
using TankTankTeste.Databases.Tank;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services)=>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IServer, Server>();        

        services.AddDbContext<TankContext>(options => 
            options.UseSqlServer(context.Configuration.GetConnectionString("Tank")), 
            ServiceLifetime.Singleton
        );

        services.InjectTankRepositories();

        services.AddSingleton<CenterWebService>();
        services.AddSingleton<CenterWebService>();
        services.AddSingleton<ConsortiaService>();
        services.AddSingleton<ServerService>();

        var buildedProvider = services.BuildServiceProvider();
        services.AddSingleton(options =>
        {
            return new WebHostBuilder()
            .UseKestrel()
            .UseUrls("http://127.0.0.1:2008/")
            .Configure(app =>
            {
                app.UseRouting();
                app.UseSoapEndpoint<ICenterWebService>("/CenterWebService.asmx", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer, false);
            })
            .ConfigureServices(services =>
            {
                services.AddSingleton(options => buildedProvider.GetRequiredService<ServerService>());
                services.AddSingleton<ICenterWebService, CenterWebService>();
                services.AddRouting();
                services.AddLogging(logging => logging.AddConsole());
                services.AddSoapCore();
            })
            .Build();
        });

        services.AddSingleton<CenterSettings>();
    })
    .UseSerilog((ctx, lc) =>
    {
        lc
            .Enrich.WithProperty("Workers", "Center")
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341/");
    })
    .Build();

host.Run();