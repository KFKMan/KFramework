using Consul;
using Microsoft.Extensions.Options;

namespace KFramework.ServiceDiscovery.Consul
{
    public class ConsulClientFactory : IConsulClientFactory
    {
        private readonly IOptionsMonitor<ConsulRegistryCenterOptions> OptionsMonitor;

        public ConsulClientFactory(IOptionsMonitor<ConsulRegistryCenterOptions> optionsMonitor)
        {
            OptionsMonitor = optionsMonitor;
        }

        public IConsulClient CreateClient()
        {
            return new ConsulClient(OptionsMonitor.CurrentValue);
        }
    }
}