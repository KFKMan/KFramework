using KFramework.Abstractions;
using KFramework.Module.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KFramework
{
    /// <summary>
    /// This class support two way configuration.
    /// You can configure with methods or/and props
    /// </summary>
    public class KApplicationSettings : IKApplicationSettings
    {
        public Type? StartupModuleType { get; set; } = null;

        public KApplicationSettings SetStartupModuleType(Type type)
        {
            StartupModuleType = type;
            return this;
        }

        public IModuleBuilder? ModuleBuilder { get; set; } = null;

        public KApplicationSettings SetModuleBuilder(IModuleBuilder moduleBuilder)
        {
            ModuleBuilder = moduleBuilder;
            return this;
        }

        public bool EnableDepensOnSystem { get; set; } = true;

        public KApplicationSettings ToggleDependsOnSystem(bool state)
        {
            EnableDepensOnSystem = state;
            return this;
        }

        public IServiceCollection? ServiceCollection { get; set; } = null;

        public KApplicationSettings SetServiceCollection(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
            return this;
        }

        public IApplicationLifeManager? LifeManager { get; set; } = null;

        public KApplicationSettings SetLifeManager(IApplicationLifeManager lifeManager)
        {
            LifeManager = lifeManager;
            return this;
        }

        public IApplicationInfo? ApplicationInfo { get; set; } = null;

        public KApplicationSettings SetApplicationInfo(IApplicationInfo? applicationInfo)
        {
            ApplicationInfo = applicationInfo;
            return this;
        }

        /// <summary>
        /// if you will or did set ConfigurationBuilder don't set this !
        /// </summary>
        public IConfiguration? Configuration { get; set; } = null;

        /// <summary>
        /// if you will or did set ConfigurationBuilder don't set this !
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public KApplicationSettings SetConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
            return this;
        }

        /// <summary>
        /// if you will or did set Configuration don't set this !
        /// </summary>
        public IConfigurationBuilder? ConfigurationBuilder { get; set; } = null;

        /// <summary>
        /// if you will or did set Configuration don't set this !
        /// </summary>
        /// <param name="configurationBuilder"></param>
        /// <returns></returns>
        public KApplicationSettings SetConfigurationBuilder(IConfigurationBuilder configurationBuilder)
        {
            ConfigurationBuilder = configurationBuilder;
            return this;
        }

        public IHostEnvironment? HostEnvironment { get; set; } = null;

        public KApplicationSettings SetHostEnvironment(IHostEnvironment hostEnvironment)
        {
            HostEnvironment = hostEnvironment;
            return this;
        }

        public string[] Args { get; set; } = Array.Empty<string>();

        public KApplicationSettings SetArgs(string[] args)
        {
            Args = args;
            return this;
        }
    }
}
