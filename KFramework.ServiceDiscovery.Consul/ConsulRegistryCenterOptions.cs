using Consul;

namespace KFramework.ServiceDiscovery.Consul
{
    public class ConsulRegistryCenterOptions : ConsulClientConfiguration, IRegistryCenterOptions
    {
        internal static string RegistryCenterSection = "RegistryCenter";

        public string Type { get; } = "Consul";

        public bool RegisterSwaggerDoc { get; set; } = true;

        public double HeartBeatIntervalSecond { get; set; } = 15;

        public double HealthCheckIntervalSecond { get; set; } = 10;

        public double HealthCheckTimeoutSecond { get; set; } = 1;

        public bool HealthCheck { get; set; } = true;

        public string RoutePath { get; set; } = "kframework/services";

        public string SwaggerDocPath { get; set; } = "kframework/swagger";
    }
}