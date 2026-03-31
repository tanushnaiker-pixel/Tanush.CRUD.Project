using Registry.Core.Config;
using Registry.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using DbUp.Engine;
using DbUp;

namespace Registry.Infrastructure.Implementation
{
    public class DatabaseMaintenanceService : IDatabaseMaintenanceService
    {
        private readonly ILogger<IDatabaseMaintenanceService> _logger;
        private readonly RegistryDbConfig _dbConfig;

        public DatabaseMaintenanceService(AppConfig config,  ILogger<IDatabaseMaintenanceService> logger)
        {
            _logger = logger;
            if (string.IsNullOrEmpty(config.RegistryDB.ConnectionString))
            {
                throw new InvalidOperationException("The connection string was not specified.");
            }

            _dbConfig = config.RegistryDB;
        }

        public bool RunMaintenance()
        {
            try
            {
                _logger.LogInformation("Maintenance process starting.");

                EnsureDatabase.For.SqlDatabase(_dbConfig.ConnectionString);

                 DatabaseUpgradeResult result = DeployChanges.To
                    .SqlDatabase(_dbConfig.ConnectionString)
                    .WithScriptsEmbeddedInAssembly(typeof(DatabaseMaintenanceService).Assembly)
                    .WithTransaction()
                    .LogToConsole()
                    .Build()
                    .PerformUpgrade();

                if (result.Successful)
                {
                    _logger.LogInformation("Maintenance performed successfully.");
                }
                else
                {
                    _logger.LogError(result.Error, "Maintenance failed.");
                }

                _logger.LogInformation("Maintenance process concluded.");
                return result.Successful;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Maintenance failed.");
                return false;
            }
        }
    }
}
