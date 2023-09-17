using KFramework.Module.Components;
using System;

namespace KFramework.Module.Annotations
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class OptionsComponentAttribute : Attribute, IComponentType
    {
        public void AddToModule(Type type, Module module)
        {
            module.Components.Add((IComponent)Activator.CreateInstance(typeof(OptionsComponent<>).MakeGenericType(type), new object[] { null }));
        }
    }
}