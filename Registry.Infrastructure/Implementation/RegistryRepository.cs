using Registry.Core.Entities;
using Registry.Infrastructure.Interfaces;
using Dapper;
using System.Data;
using Registry.Core;
using Microsoft.Extensions.Logging;

namespace Registry.Infrastructure.Implementation
{
    public class RegistryRepository : IRegistryRepository
    {
        private readonly IRegistryDBContext _dbContext;
        private readonly ILogger<IRegistryRepository> _logger;

        public RegistryRepository(IRegistryDBContext dbContext, ILogger<IRegistryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> AddUserAsync(RegistrationInformation registrationInformation, CancellationToken cancellationToken)
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
            parameters.Add("ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);

            bool result = await _dbContext.ExecuteAsync(ProcNames.ADD_USER, parameters, cancellationToken);
            HandleErrorIfAny(parameters, "Adding the User failed");

            return result;
        }

        public async Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Id", id);
            parameters.Add("ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);

            bool result = await _dbContext.ExecuteAsync(ProcNames.DELETE_USER, parameters, cancellationToken);
            HandleErrorIfAny(parameters, "Deleting the User failed");

            return result;
        }

        public async Task<List<RegistrationInformation>?> GetAllAsync(CancellationToken cancellationToken)
        {
            IEnumerable<RegistrationInformation>? result = await _dbContext.QueryAsync<RegistrationInformation>(ProcNames.GET_ALL_USERS, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken);
            return result?.ToList() ?? [];
        }

        public async Task<RegistrationInformation?> GetUserAsync(Guid id, CancellationToken cancellationToken)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            var result = await _dbContext.QueryFirstOrDefaultAsync<RegistrationInformation>(ProcNames.GET_USER, parameters, cancellationToken: cancellationToken);
            return result;
        }

        public async Task<bool> UpdateUserAsync(RegistrationInformation registrationInformation, CancellationToken cancellationToken)
        {            
            DynamicParameters parameters = new();
            parameters.Add("@Id", registrationInformation.Id);
            parameters.Add("IdNo", registrationInformation.IdNo);
            parameters.Add("@FirstName", registrationInformation.FirstName);
            parameters.Add("@LastName", registrationInformation.LastName);
            parameters.Add("@Email", registrationInformation.Email);
            parameters.Add("@Phone", registrationInformation.Phone);
            parameters.Add("@StreetAddress", registrationInformation.StreetAddress);
            parameters.Add("@Suburb", registrationInformation.Suburb);
            parameters.Add("@City", registrationInformation.City);
            parameters.Add("@Province", registrationInformation.Province);
            parameters.Add("ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);

            bool result  = await _dbContext.ExecuteAsync(ProcNames.UPDATE_USER, parameters, cancellationToken);
            HandleErrorIfAny(parameters, "Updating the User failed");

            return result;
        }

        private void HandleErrorIfAny(DynamicParameters parameters, string logDescription)
        {
            int? errorCode = parameters.Get<int?>("ErrorCode");

            if (errorCode != null)
            {
                _logger.LogInformation("{Description}: {ErrorDescription}", logDescription, errorCode.GetErrorDescription());
            }
        }
    }
}
