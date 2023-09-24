using KFramework.Module.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace KFramework.Abstractions
{
    public interface IKApplication : IDisposable
    {
        Type StartupModuleType { get; }
        IApplicationInfo ApplicationInfo { get; }
        IServiceProvider ServiceProvider { get; }
        IServiceCollection Services { get; }
        IApplicationLifeManager LifeManager { get; }
        IConfiguration Configuration { get; }
        IModule Module { get; }
    }
}