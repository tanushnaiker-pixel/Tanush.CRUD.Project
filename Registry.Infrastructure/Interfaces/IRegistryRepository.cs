using Registry.Core.Entities;

namespace Registry.Infrastructure.Interfaces
{
    public interface IRegistryRepository
    {
        Task<List<RegistrationInformation>> GetAllAsync();
        Task<RegistrationInformation> GetUserAsync(string id);
        Task AddUserAsync(RegistrationInformation registrationInformation);
        Task UpdateUserAsync(RegistrationInformation registrationInformation);
        Task DeleteUserAsync(string id);
    }
}
