using KFramework.Extensions;
using KFramework.Module.Abstractions;
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

        //public Module Module { get; set; } //??

        public void ConfigureServices(IModule module, IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            services.Add(_serviceDescriptor);
        }

        public IComponentInfo GetInfo()
        {
            return new ComponentInfo(
                            _serviceDescriptor.ServiceType.Name,
                            "Service",
                            new Dictionary<string, object>
                            {
                                { "ServiceType", _serviceDescriptor.ServiceType.Name },
                                { "ImplementationType", _serviceDescriptor.ImplementationType.NullableActionWithReturn((T)=>T.FullName.DefaultIfNull(string.Empty),string.Empty)},
                                { "LifeTime", _serviceDescriptor.Lifetime }
                            });
        }
    }
}