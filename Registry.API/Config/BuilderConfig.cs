using Registry.Core.Config;
using Registry.Infrastructure.Contexts;
using Registry.Infrastructure.Implementation;
using Registry.Infrastructure.Interfaces;

namespace Registry.API.Config
{
    public static class BuilderConfig
    {
        public static WebApplicationBuilder ConfigureSerivces(this WebApplicationBuilder builder, AppConfig config)
        {
            builder.Services.AddSingleton(config);// Need to understand what Willow said.

            // Repositories
            builder.Services.AddSingleton<IRegistryRepository, RegistryRepository>();

            // DB Maintenance
            builder.Services.AddSingleton<IDatabaseMaintenanceService, DatabaseMaintenanceService>();

            // Contexts
            builder.Services.AddSingleton<IRegistryDBContext, RegistryDBContext>();

            builder.Services.AddHealthChecks();

            return builder;
        }
    }
}
