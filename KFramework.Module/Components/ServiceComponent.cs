using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace KFramework.Module.Components
{
    public class ServiceComponent : IComponent
    {
        readonly ServiceDescriptor _serviceDescriptor;

        public ServiceComponent(ServiceDescriptor serviceDescriptor)
        {
            _serviceDescriptor = serviceDescriptor;
        }

        public Module Module { get; set; }

        public void ConfigureServices(Module module, IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            services.Add(_serviceDescriptor);
        }

        public ComponentInfo GetInfo()
        {
            return new ComponentInfo(
                            _serviceDescriptor.ServiceType.Name,
                            "Service",
                            new Dictionary<string, object>
                            {
                                { "ServiceType", _serviceDescriptor.ServiceType.Name },
                                { "ImplementationType", _serviceDescriptor.ImplementationType.FullName },
                                { "LifeTime", _serviceDescriptor.Lifetime }
                            });
        }
    }
}