using API.Services;
using Microsoft.EntityFrameworkCore;
using Tank.DI;
using Tank;
using Shared.DI;
using API.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AuthService>();
builder.Services.AddDbContext<TankContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Tank")),
    ServiceLifetime.Singleton
);

var settings = builder.Services.InjectSettings<ApiSettings>(builder.Configuration);

builder.Services.InjectTankRepositories();
builder.Services.InjectCenterClient(settings.CenterWebServerUrl);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
