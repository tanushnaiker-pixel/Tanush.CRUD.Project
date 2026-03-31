using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Core.Config
{
    public class AppConfig
    {
        public RegistryDbConfig RegistryDB { get; set; } = new();
    }
}
