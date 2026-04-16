using Registry.Core.Entities;

namespace Registry.Application.Interfaces
{
    public interface IRegistryService
    {
        Task<bool> AddUserAsync(RegistrationInformation registrationInformation);
        Task<bool> DeleteUserAsync(Guid id);
        Task<List<RegistrationInformation>> GetAllAsync();
        Task<RegistrationInformation> GetUserAsync(Guid id);
        Task<bool> UpdateUserAsync(RegistrationInformation registrationInformation);
    }
}
