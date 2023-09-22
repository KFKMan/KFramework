using System;

namespace KFramework.Module.Abstractions
{
    public interface IComponentType
    {
        public abstract void AddToModule(Type type, IModule module);
    }
}
