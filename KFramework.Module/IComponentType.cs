using System;

namespace KFramework.Module
{
    public interface IComponentType
    {
        public abstract void AddToModule(Type type, Module module);
    }
}
