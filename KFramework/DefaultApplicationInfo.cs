namespace KFramework
{
    public class DefaultApplicationInfo : IApplicationInfo
    {
        public DefaultApplicationInfo() { }
        public DefaultApplicationInfo(KApplicationCreationOptions options) 
        {
            ApplicationName = options.Configuration.TryGetOrNull<string>(IApplicationInfo.ApplicationNameKey);
            ApplicationDescription = options.Configuration.TryGetOrNull<string>(IApplicationInfo.ApplicationDescriptionKey);
        }

        public string? ApplicationName { get; } = null;
        public string? ApplicationDescription { get; } = null;
        public string InstanceId { get; } = Guid.NewGuid().ToString();
    }
}
