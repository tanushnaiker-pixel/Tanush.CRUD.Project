using Registry.Application.Interfaces;
using Registry.Core.Entities;
using Registry.Infrastructure.Interfaces;

namespace Registry.Application.Implementation
{
    public class RegistryService : IRegistryService
    {
        private readonly IRegistryRepository _registryRepository;

        public RegistryService(IRegistryRepository registryRepository)
        {
            _registryRepository = registryRepository;
        }

        public async Task<bool> AddUserAsync(RegistrationInformation registrationInformation, CancellationToken cancellationToken)
        {
            return await _registryRepository.AddUserAsync(registrationInformation, cancellationToken);
        }

        public async Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _registryRepository.DeleteUserAsync(id, cancellationToken);
        }

        public Task<List<RegistrationInformation>?> GetAllAsync(CancellationToken cancellationToken)
        {
            return _registryRepository.GetAllAsync(cancellationToken);
        }

        public Task<RegistrationInformation?> GetUserAsync(Guid id, CancellationToken cancellationToken)
        {
            return _registryRepository.GetUserAsync(id, cancellationToken);
        }

        public Task<bool> UpdateUserAsync(RegistrationInformation registrationInformation, CancellationToken cancellationToken)
        {
            return _registryRepository.UpdateUserAsync(registrationInformation, cancellationToken);
        }
    }
}
