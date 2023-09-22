using KFramework.Module.Abstractions;
using KFramework.Module.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KFramework.Module
{
    public static class Package
    {
        public static void AddModule(this IModule module, IModule submodule)
        {
            module.Modules.Add(submodule);
        }

        public static void AddService<TService>(this IModule module, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            module.Components.Add(new ServiceComponent(new ServiceDescriptor(typeof(TService), typeof(TService), serviceLifetime)));
        }

        public static void AddService<TContract, TService>(this IModule module, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            module.Components.Add(new ServiceComponent(new ServiceDescriptor(typeof(TContract), typeof(TService), serviceLifetime)));
        }

        public static void AddService<TContract, TService>(this IModule module, TService instance) where TService : notnull
        {
            module.Components.Add(new ServiceComponent(new ServiceDescriptor(typeof(TContract), instance)));
        }

        public static void AddService<TService>(this IModule module, TService instance) where TService : notnull
        {
            module.Components.Add(new ServiceComponent(new ServiceDescriptor(typeof(TService), instance)));
        }

        public static void AddOptions<TOptions>(this IModule module)
            where TOptions : class, new()
        {
            module.Components.Add(new OptionsComponent<TOptions>());
        }

        public static TOptions GetOptions<TOptions>(this IModule module, IConfiguration configuration)
           where TOptions : class, new()
        {
            foreach (IComponent component in module.Components)
            {
                if (component is OptionsComponent<TOptions> optionsComponent)
                {
                    return optionsComponent.Get(module, configuration);
                }
            }

            throw new InvalidOperationException($"No options registered for {typeof(TOptions).Name}.");
        }
    }
}