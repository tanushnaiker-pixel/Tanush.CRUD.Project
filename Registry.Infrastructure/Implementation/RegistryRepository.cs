using Microsoft.Extensions.Logging;
using Registry.Core.Entities;
using Registry.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;


namespace Registry.Infrastructure.Implementation
{
    public class RegistryRepository : IRegistryRepository
    {
        private readonly IRegistryDBContext _dbContext;
        private readonly ILogger<IRegistryRepository> _logger;

        public RegistryRepository(IRegistryDBContext dbContext, ILogger<RegistryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> AddUser(RegistrationInformation user)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Id", user.Id);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Phone", user.Phone);
            parameters.Add("@StreetAddress", user.StreetAddress);
            parameters.Add("@Suburb", user.Suburb);
            parameters.Add("@City", user.City);
            parameters.Add("@Province", user.Province);

            return await _dbContext.ExecuteAsync("2026040102_AddUser", parameters);
        }

        public async Task<bool> DeleteUser(RegistrationInformation user)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Id", user.Id);
            return await _dbContext.ExecuteAsync("2026040106_DeleteUser", parameters);
        }

        public async Task<IEnumerable<RegistrationInformation>> GetAllUsers()
        {

            return await _dbContext.QueryAsync<RegistrationInformation>("2026040103_GetAllUsers", commandType: CommandType.StoredProcedure);
        }

        public async Task<RegistrationInformation> GetUser(string id)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Id", id);
            return await _dbContext.QueryFirstOrDefaultAsync<RegistrationInformation>("2026040104_GetUser", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateUser(RegistrationInformation user)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Id", user.Id);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Phone", user.Phone);
            parameters.Add("@StreetAddress", user.StreetAddress);
            parameters.Add("@Suburb", user.Suburb);
            parameters.Add("@City", user.City);
            parameters.Add("@Province", user.Province);

            return await _dbContext.ExecuteAsync("2026040105_UpdateUser", parameters);
        }
    }
}
