using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Core.Config
{
    public class RegistryDbConfig
    {
        public string ConnectionString { get; set; } = string.Empty;
        public bool ShouldRunMaintenanceOnStartUp { get; set; }  = true;
    }
}
