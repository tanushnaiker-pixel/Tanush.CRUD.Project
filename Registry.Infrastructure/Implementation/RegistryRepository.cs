using Registry.Core.Entities;
using Registry.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace Registry.Infrastructure.Implementation
{
    public class RegistryRepository: IRegistryRepository
    {
        private readonly IRegistryDBContext _dbContext;

    }
}
