using Microsoft.AspNetCore.Builder;
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

    public class KAspApplicationBuilder
    {
        private WebApplicationBuilder Builder;

        public KAspApplicationBuilder(WebApplicationBuilder applicationbuilder)
        {
            Builder = applicationbuilder;
        }

        public KAspApplication CreateApp()
        {
            return new KAspApplication(typeof(KAspApplicationBuilder), Builder.Services,configurationBuilder: Builder.Configuration);
        }
    }

    public static class KWebApplication
    {
        public static KAspApplicationBuilder CreateBuilder(this WebApplicationBuilder builder)
        {
            return new KAspApplicationBuilder(builder);
        }

        public static KAspApplicationBuilder CreateBuilder()
        {
            return WebApplication.CreateBuilder().CreateBuilder();
        }

        public static KAspApplicationBuilder CreateBuilder(string[] args)
        {
            return WebApplication.CreateBuilder(args).CreateBuilder();
        }

        public static KAspApplicationBuilder CreateBuilder(WebApplicationOptions options)
        {
            return WebApplication.CreateBuilder(options).CreateBuilder();
        }
    }
}