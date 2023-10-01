using Consul;
using KFramework.Abstractions;
using KFramework.ServiceDiscovery.Abstractions;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Linq;
using System.Net;

namespace KFramework.ServiceDiscovery.Consul
{
    public class ServiceInfo : IServiceInfo
    {
        public ServiceInfo(IEndpoint endpoint)
        {
            Endpoint = endpoint;
        }

        public const string NoServiceName = "NoName";

        public string ServiceName { get; set; } = NoServiceName;
        public IEndpoint Endpoint { get; set; }
    }

    public class ConsulDiscover
    {
        public IConsulClientFactory ClientFactory;
        public IOptions<ConsulRegistryCenterOptions> ConsulRegistryCenterOptions;

        public ConsulDiscover(IConsulClientFactory consulClientFactory, IOptions<ConsulRegistryCenterOptions> consulRegistryCenterOptions)
        {
            ClientFactory = consulClientFactory;
            ConsulRegistryCenterOptions = consulRegistryCenterOptions;
        }

        public async Task<bool> AddService(IServiceInfo serviceinfo)
        {
            using (var client = ClientFactory.CreateClient())
            {
                var endpoint = serviceinfo.Endpoint;
                var agentServiceRegistration = new AgentServiceRegistration()
                {
                    ID = endpoint.GetAddress(),
                    Address = endpoint.Host,
                    Port = endpoint.Port,
                    Name = serviceinfo.ServiceName,
                    EnableTagOverride = false
                };
                var serviceRegisterResult = await client.Agent.ServiceRegister(agentServiceRegistration);
                if (serviceRegisterResult == null || serviceRegisterResult.StatusCode != HttpStatusCode.OK)
                {
                    return false;
                }

                return true;
            }
        }
    }
}