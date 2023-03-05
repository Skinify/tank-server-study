using API.Services;
using Microsoft.EntityFrameworkCore;
using Tank.DI;
using Tank;
using Shared.DI;
using API.Config;
using API.DTOs.Mapping;
using Serilog;
using API.Services._Interface;
using API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var settings = builder.Services.InjectSettings<ApiSettings>(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IItemsService, ItemsService>();
builder.Services.AddDbContext<TankContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Tank")),
    ServiceLifetime.Singleton
);

builder.Services.InjectTankRepositories();
builder.Services.InjectCenterClient(settings.CenterWebServerUrl);
builder.Services.InjectSharedDTOMapping();
builder.Services.AddAutoMapper(typeof(DTOMapping));

builder.Host.UseSerilog((ctx, lc) =>
{
    lc
        .Enrich.WithProperty("APIs", "GameAPI")
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.Seq(settings.Seq);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ResponseTimeMiddleware>();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
