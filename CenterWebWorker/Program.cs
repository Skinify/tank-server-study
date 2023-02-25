using CenterWorker.Endpoints;
using CenterWorker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddSingleton<TestService>();
builder.WebHost.
    UseKestrel()
    .UseUrls("http://127.0.0.1:2008/");

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<WebService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
