using Registry.Core.Entities;

namespace Registry.Infrastructure.Interfaces
{
    public interface IRegistryRepository
    {
        Task<List<RegistrationInformation>?> GetAllAsync(CancellationToken cancellationToken);
        Task<RegistrationInformation?> GetUserAsync(int id, CancellationToken cancellationToken);
        Task<bool> AddUserAsync(RegistrationInformation registrationInformation, CancellationToken cancellationToken);
        Task<bool> UpdateUserAsync(RegistrationInformation registrationInformation, CancellationToken cancellationToken);
        Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken);
    }
}
