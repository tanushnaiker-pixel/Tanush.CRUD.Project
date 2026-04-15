using Registry.Core.Entities;
using Registry.Infrastructure.Interfaces;
using Dapper;
using System.Data;

namespace Registry.Infrastructure.Implementation
{
    public class RegistryRepository : IRegistryRepository
    {
        private readonly IRegistryDBContext _dbContext;

        public RegistryRepository(IRegistryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddUserAsync(RegistrationInformation registrationInformation)
        {
            DynamicParameters parameters = new();
            parameters.Add("@IdNo", registrationInformation.IdNo);
            parameters.Add("@FirstName", registrationInformation.FirstName);
            parameters.Add("@LastName", registrationInformation.LastName);
            parameters.Add("@Email", registrationInformation.Email);
            parameters.Add("@Phone", registrationInformation.Phone);
            parameters.Add("@StreetAddress", registrationInformation.StreetAddress);
            parameters.Add("@Suburb", registrationInformation.Suburb);
            parameters.Add("@City", registrationInformation.City);
            parameters.Add("@Province", registrationInformation.Province);

            bool result = await _dbContext.ExecuteAsync("AddUser", parameters);
            return result;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            bool result = await _dbContext.ExecuteAsync("DeleteUser", parameters);
            return result;
        }

        public async Task<List<RegistrationInformation>> GetAllAsync()
        {
            var result = await _dbContext.QueryAsync<RegistrationInformation>("GetAllUsers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<RegistrationInformation> GetUserAsync(Guid id)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            var result = await _dbContext.QueryFirstOrDefaultAsync<RegistrationInformation>("GetUser", parameters);
            return result;
        }

        public async Task<bool> UpdateUserAsync(RegistrationInformation registrationInformation)
        {            
            DynamicParameters parameters = new();
            parameters.Add("@Id", registrationInformation.Id);
            parameters.Add("@FirstName", registrationInformation.FirstName);
            parameters.Add("@LastName", registrationInformation.LastName);
            parameters.Add("@Email", registrationInformation.Email);
            parameters.Add("@Phone", registrationInformation.Phone);
            parameters.Add("@StreetAddress", registrationInformation.StreetAddress);
            parameters.Add("@Suburb", registrationInformation.Suburb);
            parameters.Add("@City", registrationInformation.City);
            parameters.Add("@Province", registrationInformation.Province);

            bool result  = await _dbContext.ExecuteAsync("UpdateUser", parameters);
            return result;
        }
    }
}
