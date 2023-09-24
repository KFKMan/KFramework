using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KFramework.Module.Abstractions
{
    public interface IModule
    {
        Type? MainType { get; }
        string Name { get; }
        Version Version { get; }
        List<IComponent> Components { get; }
        List<IModule> Modules { get; }

        void ConfigureServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment);
        IEnumerable<IComponent> GetComponents();
        IModuleInfo GetInfo();
    }
}