using Registry.Core.Config;
using Registry.Infrastructure.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Registry.API.Config
{
    [ExcludeFromCodeCoverage(Justification = "Maintenance dependency injection setup")]
    public static class MaintenanceConfig
    {
        public static void RunDBMaintenance(this WebApplication app, AppConfig config)
        {
            if (config.RegistryDB.ShouldRunMaintenanceOnStartUp)
            {
                IDatabaseMaintenanceService dbMaintenance = app.Services.GetRequiredService<IDatabaseMaintenanceService>();

                dbMaintenance.RunMaintenance();
            }
        }
    }
}
