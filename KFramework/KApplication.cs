using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System;
using Microsoft.Extensions.Configuration;

namespace KFramework
{
    public class KApplication : IKApplication
    {
        public Type StartupModuleType { get; }

        public IConfigurationBuilder? ConfigurationBuilder { get; } = null;

        public IConfiguration Configuration { get; }

        public IApplicationInfo ApplicationInfo { get; }

        public IServiceProvider ServiceProvider { get; set; } = default!;

        public IServiceCollection Services { get; set; }

        public IApplicationLifeManager LifeManager { get; }

        public string? ApplicationName { get; }

        public string InstanceId { get; } = Guid.NewGuid().ToString();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startupModuleType"></param>
        /// <param name="services"></param>
        /// <param name="lifeManager"></param>
        /// <param name="applicationInfo"></param>
        /// <param name="configuration"></param>
        /// <param name="configurationBuilder">don't set if you are set configuration variable</param>
        /// <param name="options"></param>
        public KApplication(Type startupModuleType,
            IServiceCollection services,IApplicationLifeManager? lifeManager=null,IApplicationInfo?
            applicationInfo = null,IConfiguration? configuration = null,IConfigurationBuilder? configurationBuilder=null,Action<KApplicationCreationOptions>? options=null)
        {
            #region InjectSelf (DI)
            services.AddSingleton<IKApplication>(this);
            services.AddSingleton<KApplication>(this);
            #endregion

            Check.NotNull(startupModuleType, nameof(startupModuleType));
            Check.NotNull(services, nameof(services));

            StartupModuleType = startupModuleType;
            Services = services;

            #region Configuration
            if (configuration != null)
            {
                Configuration = configuration;
            }
            else
            {
                if(configurationBuilder != null)
                {
                    ConfigurationBuilder = configurationBuilder;
                }
                else
                {
                    ConfigurationBuilder = new ConfigurationBuilder();
                }
                Configuration = ConfigurationBuilder.Build();
            }
            var accessor = services.AddOrGetExtendedObjectAccessor<IKApplication, IConfiguration>(x => x.Configuration, this);
            #endregion

            #region ApplicationCreationOptions
            var creationoptions = new KApplicationCreationOptions(Services, Configuration);
            #endregion

            #region LifeManager
            if (lifeManager != null)
            {
                LifeManager = lifeManager;
            }
            else
            {
                LifeManager = new DefaultLifeManager();
            }
            services.AddSingleton<IApplicationLifeManager>(LifeManager);
            #endregion

            #region ApplicationInfo
            if (applicationInfo != null)
            {
                ApplicationInfo = applicationInfo;
            }
            else
            {
                ApplicationInfo = new DefaultApplicationInfo(creationoptions);
            }
            services.AddSingleton<IApplicationInfo>(ApplicationInfo);
            #endregion

            #region Core Services
            services.AddCoreServices();
            services.AddCoreKServices(this);
            #endregion
        }

        public void Dispose()
        {
            
        }
    }
}
