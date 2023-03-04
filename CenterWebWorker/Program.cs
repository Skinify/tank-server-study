using CenterService.Config;
using CenterService.Services;
using CenterWorker.Endpoints;
using Serilog;
using Shared.DI;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var config = builder.Services.InjectSettings<CenterSettings>(builder.Configuration);
        config.ValidateSettings();

        builder.Host.UseSerilog((ctx, lc) =>
        {
            lc
                .Enrich.WithProperty("Workers", "Center")
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Seq(config.Seq);

        });

        builder.Services.InjectSharedDTOMapping();

        builder.Services.AddGrpc();
        builder.Services.AddSingleton<ServerService>();
        builder.WebHost.
            UseKestrel()
            .UseUrls(config.ListeningUrls);

        var app = builder.Build();

        app.MapGrpcService<WebService>();
        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();
    }
}