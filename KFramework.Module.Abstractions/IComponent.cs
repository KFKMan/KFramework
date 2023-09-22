using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KFramework.Module.Abstractions
{
    public interface IComponent
    {
        void ConfigureServices(IModule module, IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment);

        IComponentInfo GetInfo();
    }
}