using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KFramework.Module
{
    public interface IComponent
    {
        void ConfigureServices(Module module, IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment);

        ComponentInfo GetInfo();
    }
}