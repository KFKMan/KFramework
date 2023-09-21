﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KFramework.Module
{
    public class Module
    {
        public Module()
        {
            ThisType = GetType();
            Name = ThisType.Name.Replace("Module", "");
            Version = ThisType.Assembly.GetName().Version ?? VersionHelper.DefaultVersion;
        }

        private Type ThisType { get; set; }

        public string Name { get; set; }

        public Version Version { get; set; }

        public List<IComponent> Components { get; } = new List<IComponent>();

        public List<Module> Modules { get; } = new List<Module>();

        public virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            foreach (IComponent component in Components)
            {
                component.ConfigureServices(this, services, configuration, hostEnvironment);
            }

            foreach (Module module in Modules)
            {
                module.ConfigureServices(services, configuration, hostEnvironment);
            }
        }

        public virtual IEnumerable<IComponent> GetComponents()
        {
            foreach (IComponent component in Components)
            {
                yield return component;
            }

            foreach (Module submodule in Modules)
            {
                foreach (IComponent component in submodule.GetComponents())
                {
                    yield return component;
                }
            }
        }

        /// <summary>
        /// Adds all components in the current namespace and descendant namespaces.
        /// </summary>
        public virtual void AddComponents()
        {
            AddComponents(ComponentsNamespaceFilter);
        }

        private bool ComponentsNamespaceFilter(Type t)
        {
            if (t.Namespace != null)
            {
                if (ThisType.Namespace == null)
                {
                    return true;
                }
                else
                {
                    return t.Namespace.StartsWith(ThisType.Namespace);
                }
            }
            return true;
        }

        public virtual void AddComponents(Func<Type, bool>? filter = null, Assembly? assembly = null)
        {
            if (assembly == null)
            {
                assembly = GetType().Assembly;
            }
            Func<Type, bool> Filter;
            if(filter != null)
            {
                Filter = filter;
            }
            else
            {
                Filter = (t) => true;
            }

            foreach (Type type in assembly.DefinedTypes)
            {
                IComponentType? annotation = GetComponentType(type);
                if (annotation != null)
                {
                    if (Filter(type))
                    {
                        annotation.AddToModule(type, this);
                    }
                }
            }
        }

        public virtual void AddComponent(Type type)
        {
            IComponentType? annotation = GetComponentType(type);
            if (annotation == null)
            {
                throw new ArgumentException($"Type {type} does not provide component information.");
            }

            annotation.AddToModule(type, this);
        }

        public virtual void AddModule(Module module)
        {
            Modules.Add(module);
        }

        public virtual IComponentType? GetComponentType(Type type)
        {
            return type.GetCustomAttributes().OfType<IComponentType>().FirstOrDefault();
        }

        public virtual ModuleInfo GetInfo()
        {
            ModuleInfo[] submodules = new ModuleInfo[Modules.Count];
            for (int i = 0; i < submodules.Length; i++)
            {
                submodules[i] = Modules[i].GetInfo();
            }

            ComponentInfo[] components = new ComponentInfo[Components.Count];
            for (int i = 0; i < components.Length; i++)
            {
                components[i] = Components[i].GetInfo();
            }

            return new ModuleInfo(Name, Version.ToString(), submodules, components);
        }
    }

    public class VersionHelper
    {
        public static Version DefaultVersion
        {
            get
            {
                return new Version(1, 0, 0, 0); //can be clone used but casting...
            }
        }
    }
}