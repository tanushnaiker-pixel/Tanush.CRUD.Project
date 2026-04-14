namespace Registry.Core.Config
{
    public class RegistryDbConfig
    {
        public string ConnectionString { get; set; } = string.Empty;
        public bool ShouldRunMaintenanceOnStartUp { get; set; }  = true;
    }
}
