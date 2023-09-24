namespace KFramework.Abstractions
{
    public interface IApplicationInfo
    {
        public string? ApplicationName { get; }
        public string? ApplicationDescription { get; }
        public Version? Version { get; }
        public string InstanceId { get; }

        public const string ApplicationNameKey = nameof(ApplicationName);
        public const string ApplicationDescriptionKey = nameof(ApplicationDescriptionKey);
    }
}