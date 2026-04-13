using Registry.Core.Config;
using Registry.Infrastructure.Implementation;
using Registry.Infrastructure.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//AppConfig config = new();

//string version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? new Version(0, 0, 0).ToString();
//builder.Configuration.GetSection("AppConfig").Bind(config);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRegistryRepository, RegistryRepository>();
//RegistryDbConfig registryDbConfig = new RegistryDbConfig();

//builder.Configuration.GetSection("RegistryDbConfig").Bind(registryDbConfig);
//builder.Services.AddSingleton(registryDbConfig);

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
