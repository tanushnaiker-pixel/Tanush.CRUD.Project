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
        Task<IEnumerable<RegistrationInformation>> GetAllUsers();
        Task<RegistrationInformation> GetUser(string id);
        Task<bool> AddUser(RegistrationInformation user);
        Task<bool> UpdateUser(RegistrationInformation user);
        Task<bool> DeleteUser(RegistrationInformation user);
    }
}
