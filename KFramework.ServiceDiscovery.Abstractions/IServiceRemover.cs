namespace KFramework.ServiceDiscovery.Abstractions
{
    public interface IServiceRemover
    {
        public Task<bool> ServiceRemovingSupported();

        public Task<bool> RemoveService();
    }
}