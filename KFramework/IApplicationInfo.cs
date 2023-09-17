namespace KFramework
{
    public interface IApplicationInfo
    {
        public string? ApplicationName { get; }
        public string? ApplicationDescription { get; }
        public string InstanceId { get; }

        public const string ApplicationNameKey = nameof(ApplicationName);
        public const string ApplicationDescriptionKey = nameof(ApplicationDescriptionKey);
    }
}