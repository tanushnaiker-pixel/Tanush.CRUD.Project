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

        public async Task<bool> AddUserAsync(RegistrationInformation registrationInformation)
        {
            return await _registryRepository.AddUserAsync(registrationInformation);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            return await _registryRepository.DeleteUserAsync(id);
        }

        public Task<List<RegistrationInformation>> GetAllAsync()
        {
            return _registryRepository.GetAllAsync();
        }

        public Task<RegistrationInformation> GetUserAsync(Guid id)
        {
            return _registryRepository.GetUserAsync(id);
        }

        public Task<bool> UpdateUserAsync(RegistrationInformation registrationInformation)
        {
            return _registryRepository.UpdateUserAsync(registrationInformation);
        }
    }
}
