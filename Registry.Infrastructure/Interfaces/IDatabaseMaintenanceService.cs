using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Infrastructure.Interfaces
{
    public interface IDatabaseMaintenanceService
    {
        bool RunMaintenance();
    }
}
