namespace KFramework.ServiceDiscovery.Abstractions
{

    public interface IServiceAdder
    {
        public Task<bool> ServiceAddingSupported();

        public Task<IAddServiceResult> AddService();
    }
}