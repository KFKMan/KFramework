using System.Reflection.Emit;

namespace KFramework.Module.Abstractions
{
    public interface IModuleBuilder : ICloneable
    {
        IModuleBuilder SetMainType(Type type);
        IModuleBuilder SetName(string name);
        IModuleBuilder SetVersion(Version version);
        IModule Build();
    }
}