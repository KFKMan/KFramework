namespace KFramework.ServiceDiscovery.Abstractions
{
    public interface IServiceGetter
    {
        public Task<bool> ServiceGettingSupported();

        public Task<bool> GetService();
    }
}