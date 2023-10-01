using Consul;

namespace KFramework.ServiceDiscovery.Consul
{
    public interface IConsulClientFactory
    {
        IConsulClient CreateClient();
    }
}