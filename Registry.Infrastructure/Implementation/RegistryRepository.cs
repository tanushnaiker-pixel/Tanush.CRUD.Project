using Registry.Core.Entities;
using Registry.Infrastructure.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Registry.Core.Config;

namespace Registry.Infrastructure.Implementation
{
    public class RegistryRepository : IRegistryRepository
    {
        private readonly AppConfig _appConfig;

        public RegistryRepository(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public async Task AddUserAsync(RegistrationInformation registrationInformation)
        {
            using var connection = GetConnection();
            await connection.ExecuteAsync("INSERT INTO Users (idNo, firstName, lastName, email, phone, streetAddress, suburb, city, province) VALUES (@IdNo, @FirstName, @LastName, @Email, @Phone, @StreetAddress, @Suburb, @City, @Province)", registrationInformation);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            using var connection = GetConnection();
            await connection.ExecuteAsync("DELETE FROM Users WHERE id = @Id", new { Id = id });
        }

        public async Task<List<RegistrationInformation>> GetAllAsync()
        {
            using var connection = GetConnection();
            var result = await connection.QueryAsync<RegistrationInformation>("SELECT * FROM Users");
            return result.ToList();
        }

        public async Task<RegistrationInformation> GetUserAsync(Guid id)
        {
            using var connection = GetConnection();
            var result = await connection.QueryFirstOrDefaultAsync<RegistrationInformation>("SELECT * FROM Users WHERE id = @Id", new { Id = id });
            return result;
        }

        public async Task UpdateUserAsync(RegistrationInformation registrationInformation)
        {
            using var connection = GetConnection();
            await connection.ExecuteAsync("UPDATE Users SET firstName = @FirstName, lastName = @LastName, email = @Email, phone = @Phone, streetAddress = @StreetAddress, suburb = @Suburb, city = @City, province = @Province WHERE idNo = @IdNo", registrationInformation);
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_appConfig.RegistryDB.ConnectionString);
        }
    }
}
