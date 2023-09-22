using KFramework.Extensions;
using KFramework.Module.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KFramework.Module.Components
{
    public class OptionsComponent<TOptions> : IComponent
        where TOptions : class, new()
    {
        public OptionsComponent(string? name = null)
        {
            Name = name.DefaultIfNull(()=>typeof(TOptions).Name.Replace("Options", ""));
        }

        public string Name { get; }

        public void ConfigureServices(IModule module, IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            IConfiguration section = GetSection(module, configuration);
            services.Configure<TOptions>(section);
        }

        public IConfiguration GetSection(IModule module, IConfiguration configuration)
        {
            string setting = $"{module.Name}:{Name}";
            IConfiguration section = configuration.GetSection(setting);
            return section;
        }

        public TOptions Get(IModule module, IConfiguration configuration)
        {
            TOptions options = new TOptions();
            GetSection(module, configuration).Bind(options);
            return options;
        }

        public IComponentInfo GetInfo()
        {
            return new ComponentInfo(
                Name,
                "Options",
                null
            );
        }
    }
}