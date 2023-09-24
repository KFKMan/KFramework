using KFramework.Abstractions;
using Microsoft.Extensions.Configuration;

namespace KFramework
{
    public class DefaultApplicationInfo : IApplicationInfo
    {
        public DefaultApplicationInfo() { }
        public DefaultApplicationInfo(KApplicationCreationOptions options) 
        {
            ApplicationName = options.Configuration.GetValue<string>(IApplicationInfo.ApplicationNameKey);
            ApplicationDescription = options.Configuration.GetValue<string>(IApplicationInfo.ApplicationDescriptionKey);
        }

        public string? ApplicationName { get; } = null;
        public string? ApplicationDescription { get; } = null;
        public Version? Version { get; } = null;
        public string InstanceId { get; } = Guid.NewGuid().ToString();
    }
}
