using Detached.Modules.Components;
using KFramework.Module;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KFramework.Module.Annotations
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ServiceComponentAttribute : Attribute, IComponentType
    {
        public ServiceLifetime LifeTime { get; set; } = ServiceLifetime.Scoped;

        public Type ContractType { get; set; }

        public void AddToModule(Type type, Module module)
        {
            module.Components.Add(new ServiceComponent(new ServiceDescriptor(ContractType ?? type, type, LifeTime)));
        }
    }
}