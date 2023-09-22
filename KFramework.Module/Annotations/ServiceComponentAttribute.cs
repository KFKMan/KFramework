using KFramework.Module;
using KFramework.Module.Abstractions;
using KFramework.Module.Components;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KFramework.Module.Annotations
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ServiceComponentAttribute : Attribute, IComponentType
    {
        public ServiceLifetime LifeTime { get; set; } = ServiceLifetime.Scoped;

        public Type? ContractType { get; set; }

        public void AddToModule(Type type, IModule module)
        {
            module.Components.Add(new ServiceComponent(new ServiceDescriptor(ContractType ?? type, type, LifeTime)));
        }
    }
}