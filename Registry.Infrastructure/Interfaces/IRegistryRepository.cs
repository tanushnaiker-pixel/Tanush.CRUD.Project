using Registry.Core.Entities;

namespace Registry.Infrastructure.Interfaces
{
    public interface IRegistryRepository
    {
        Task<List<RegistrationInformation>> GetAllAsync();
        Task<RegistrationInformation> GetUserAsync(Guid id);
        Task<bool> AddUserAsync(RegistrationInformation registrationInformation);
        Task<bool> UpdateUserAsync(RegistrationInformation registrationInformation);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
