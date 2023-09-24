using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System;
using Microsoft.Extensions.Configuration;
using KFramework.Extensions;
using KFramework.Module.Abstractions;
using KFramework.Abstractions;
using KFramework.Module;
using Microsoft.Extensions.Hosting;

namespace KFramework
{
    public class KApplication : IKApplication
    {
        public Type StartupModuleType { get; }

        public IConfigurationBuilder? ConfigurationBuilder { get; private set; } = null;

        public IConfiguration Configuration { get; private set; }

        public IApplicationInfo ApplicationInfo { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; } = default!;

        public IServiceCollection Services { get; private set; }

        public IApplicationLifeManager LifeManager { get; private set; }

        public IModule Module { get; }

        public IModuleBuilder ModuleBuilder { get; }

        public IHostEnvironment HostEnvironment { get; private set; }

        public IHost? Host { get; } = null;

        public string? ApplicationName { get; }

        public string InstanceId { get; } = Guid.NewGuid().ToString();

        public KApplication(KApplicationSettings settings)
        {
            settings.StartupModuleType.ThrowIfNull();
            settings.ServiceCollection.ThrowIfNull();

            StartupModuleType = settings.StartupModuleType!;
            Services = settings.ServiceCollection!;

            #region Inject Self (DI)
            Services.AddSingleton<IKApplication>(this);
            Services.AddSingleton<KApplication>(this);
            #endregion

            #region Configuration
            if (settings.Configuration.IsNotNull())
            {
                Configuration = settings.Configuration!;
            }
            else
            {
                if (settings.ConfigurationBuilder.IsNotNull())
                {
                    ConfigurationBuilder = settings.ConfigurationBuilder;
                }
                else
                {
                    ConfigurationBuilder = new ConfigurationBuilder();
                }
                Configuration = ConfigurationBuilder!.Build();
            }
            //it's needed?
            //var accessor = Services.AddOrGetExtendedObjectAccessor<IKApplication, IConfiguration>(x => x.Configuration, this);
            #endregion

            #region HostEnvironment
            if(settings.HostEnvironment != null)
            {
                HostEnvironment = settings.HostEnvironment;
            }
            else
            {
                var hostbuilder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(settings.Args);
                var host = hostbuilder.Build();
                HostEnvironment = hostbuilder.Environment;
            }
            #endregion

            #region ApplicationCreationOptions
            var creationoptions = new KApplicationCreationOptions(Services, Configuration);
            #endregion

            #region ApplicationInfo
            if (settings.ApplicationInfo.IsNotNull())
            {
                ApplicationInfo = settings.ApplicationInfo!;
            }
            else
            {
                ApplicationInfo = new DefaultApplicationInfo(creationoptions);
            }
            Services.AddSingleton<IApplicationInfo>(ApplicationInfo);
            #endregion

            #region Module
            if (settings.ModuleBuilder.IsNotNull())
            {
                ModuleBuilder = settings.ModuleBuilder!;
            }
            else
            {
                ModuleBuilder = new ModuleBuilder();
            }

            if (ApplicationInfo.ApplicationName.IsNotNull()) {
                ModuleBuilder.SetName(ApplicationInfo.ApplicationName!);
            }
            ModuleBuilder.SetMainType(StartupModuleType);
            if (ApplicationInfo.Version.IsNotNull())
            {
                ModuleBuilder.SetVersion(ApplicationInfo.Version!);
            }
            Module = ModuleBuilder.Build();

            #endregion

            #region LifeManager
            if (settings.LifeManager.IsNotNull())
            {
                LifeManager = settings.LifeManager!;
            }
            else
            {
                LifeManager = new DefaultLifeManager();
            }
            Services.AddSingleton<IApplicationLifeManager>(LifeManager);
            #endregion

            #region Core Services
            Services.AddCoreServices();
            Services.AddCoreKServices(this);
            #endregion
        }

        public void Configure()
        {
            Module.ConfigureServices(Services, Configuration, HostEnvironment);
        }

        public void Dispose()
        {
            
        }
    }
}
