using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace KFramework
{
    public interface IKApplication : IDisposable
    {
        Type StartupModuleType { get; }
        IApplicationInfo ApplicationInfo { get; }
        IServiceProvider ServiceProvider { get; set; }
        IServiceCollection Services { get; set; }
        IApplicationLifeManager LifeManager { get; }
        IConfiguration Configuration { get; }
    }
}