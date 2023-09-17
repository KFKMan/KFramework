using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KFramework.Integration.AspCore
{
    public class KAspApplication : KApplication
    {
        public KAspApplication(Type startupModuleType, IServiceCollection services, IApplicationLifeManager? lifeManager = null, IApplicationInfo? applicationInfo = null, IConfiguration? configuration = null, IConfigurationBuilder? configurationBuilder = null, Action<KApplicationCreationOptions>? options = null) : base(startupModuleType, services, lifeManager, applicationInfo, configuration, configurationBuilder, options)
        {
        }
    }
}