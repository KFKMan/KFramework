using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace KFramework
{
    public class KApplicationCreationOptions
    {
        public IServiceCollection Services { get; }

        public IConfiguration Configuration { get; }
        
        public KApplicationCreationOptions(IServiceCollection services,IConfiguration configuration)
        {
            Services = services;
            Configuration = configuration;
        }
    }
}
