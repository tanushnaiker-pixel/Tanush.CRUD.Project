using Registry.API.Config;
using Registry.Core.Config;
using Registry.Infrastructure.Implementation;
using Registry.Infrastructure.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

AppConfig config = new();
builder.Configuration.GetSection("AppConfig").Bind(config);
builder.ConfigureSerivces(config);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RunDBMaintenance(config);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
