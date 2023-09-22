namespace KFramework.Module.Abstractions
{
    public interface IModuleInfo
    {
        string Name { get; }
        string Version { get; }
        IReadOnlyList<IModuleInfo> Modules { get; }
        IReadOnlyList<IComponentInfo> Components { get; }
    }

    public interface IComponentInfo
    {
        string Name { get; }

        string Type { get; }

        IReadOnlyDictionary<string, object> Properties { get; }
    }
}