using Registry.Core.Entities;

namespace Registry.Infrastructure.Interfaces
{
    public interface IRegistryRepository
    {
        Task<List<RegistrationInformation>> GetAllAsync();
        Task<RegistrationInformation> GetUserAsync(Guid id);
        Task AddUserAsync(RegistrationInformation registrationInformation);
        Task UpdateUserAsync(RegistrationInformation registrationInformation);
        Task DeleteUserAsync(Guid id);
    }
}
