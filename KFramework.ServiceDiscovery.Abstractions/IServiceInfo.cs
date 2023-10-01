using KFramework.Abstractions;

namespace KFramework.ServiceDiscovery.Abstractions
{
    public interface IServiceInfo
    {
        IEndpoint Endpoint { get; }
        string ServiceName { get; }
    }
}