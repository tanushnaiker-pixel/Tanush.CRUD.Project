using Dapper;
using System.Data;

namespace Registry.Infrastructure.Interfaces
{
    public interface IRegistryDBContext
    {
        Task<bool> ExecuteAsync(string query, DynamicParameters? queryParams = null);
        Task<bool> IsHealthy();
        Task<IEnumerable<T>?> QueryAsync<T>(string query, object? queryParams = null, CommandType? commandType = null, int? timeoutInSec = 30);
    }
}
