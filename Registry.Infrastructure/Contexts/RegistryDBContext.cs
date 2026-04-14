using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Registry.Core.Config;
using Registry.Infrastructure.Interfaces;
using System.Data;


namespace Registry.Infrastructure.Contexts
{
    public class RegistryDBContext : IRegistryDBContext
    {
        private readonly string _connectionString;
        private readonly ILogger<RegistryDBContext> _logger;

        private const string SQL_EXCEPTION = "{Message}: {Command}";

        public RegistryDBContext(AppConfig config, ILogger<RegistryDBContext> logger)
        {
            _connectionString = config.RegistryDB.ConnectionString;
            _logger = logger;
        }

        public async Task<bool> IsHealthy()
        {
            using SqlConnection connection = new(_connectionString);

            const string sql = "SELECT 1";
            CommandDefinition command = new(commandText: sql, commandType: CommandType.Text);
            try
            {
                return await connection.QueryFirstOrDefaultAsync<int>(command) == 1;
            }
            catch (Exception Ex)
            {
                _logger.LogWarning(Ex, SQL_EXCEPTION, "health check failure", command.CommandText);
                return default;
            }
        }

        public async Task<IEnumerable<T>?> QueryAsync<T>(string query, object? queryParams = null, CommandType? commandType = null, int? timeoutInSec = 30)
        {
            using SqlConnection connection = new(_connectionString);

            CommandDefinition command = new(commandText: query, parameters: queryParams, commandType: commandType, commandTimeout: timeoutInSec);

            try
            {
                IEnumerable<T> res = await connection.QueryAsync<T>(command);

                return res;
            }
            catch (SqlException Ex)
            {
                _logger.LogWarning(Ex, SQL_EXCEPTION, "SqlException", command.CommandText);
                return default;
            }
            catch (OperationCanceledException Ex)
            {
                _logger.LogWarning(Ex, SQL_EXCEPTION, "Operation was canceled", command.CommandText);
                return default;
            }
            catch (Exception Ex)
            {
                _logger.LogWarning(Ex, SQL_EXCEPTION, "Unhandled exception occurred", command.CommandText);
                return default;
            }
        }

        public async Task<bool> ExecuteAsync(string query, DynamicParameters? queryParams = null)
        {
            using SqlConnection connection = new(_connectionString);

            CommandDefinition command = new(commandText: query, parameters: queryParams, commandType: CommandType.StoredProcedure);

            try
            {
                int rowsEffected = await connection.ExecuteAsync(command);

                _logger.LogDebug("Rows Effected {Row}", rowsEffected);
                return rowsEffected > 0;
            }
            catch (SqlException Ex)
            {
                _logger.LogWarning(Ex, SQL_EXCEPTION, "SqlException", command.CommandText);
                return false;
            }
            catch (OperationCanceledException Ex)
            {
                _logger.LogWarning(Ex, SQL_EXCEPTION, "Operation was canceled", command.CommandText);
                return false;
            }
            catch (Exception Ex)
            {
                _logger.LogWarning(Ex, SQL_EXCEPTION, "Unhandled exception occurred", command.CommandText);
                return false;
            }
        }
    }
}
