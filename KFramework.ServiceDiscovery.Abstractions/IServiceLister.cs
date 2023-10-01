namespace KFramework.ServiceDiscovery.Abstractions
{
    public interface IServiceLister
    {
        public Task<bool> ServiceListingSupported();

        public Task<bool> GetServices();
    }
}