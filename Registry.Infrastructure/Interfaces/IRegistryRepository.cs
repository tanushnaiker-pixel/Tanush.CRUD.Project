using Registry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
