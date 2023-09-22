using KFramework.Module.Abstractions;
using KFramework.Module.Components;
using System;

namespace KFramework.Module.Annotations
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class OptionsComponentAttribute : Attribute, IComponentType
    {
        public void AddToModule(Type type, IModule module)
        {
            var instance = Activator.CreateInstance(typeof(OptionsComponent<>).MakeGenericType(type), null);
            if(instance is IComponent == false)
            {
                throw new Exception("Instance create error !");
            }
            module.Components.Add((instance as IComponent)!);
        }
    }
}