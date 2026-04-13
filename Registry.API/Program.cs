using Registry.Core.Config;
using Registry.Infrastructure.Contexts;
using Registry.Infrastructure.Implementation;
using Registry.Infrastructure.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

AppConfig config = new();

builder.Services.AddSingleton(config);
builder.Configuration.GetSection("AppConfig").Bind(config);
RegistryDbConfig registryDbConfig = new RegistryDbConfig();

builder.Configuration.GetSection("RegistryDbConfig").Bind(registryDbConfig);
builder.Services.AddSingleton(registryDbConfig);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRegistryDBContext, RegistryDBContext>();
builder.Services.AddScoped<IRegistryRepository, RegistryRepository>();



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
