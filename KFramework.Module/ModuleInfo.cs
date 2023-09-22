using KFramework.Module.Abstractions;
using System;
using System.Collections.Generic;

namespace KFramework.Module
{
    public class ModuleInfo : IModuleInfo
    {
        public ModuleInfo(string name, string version, IModuleInfo[] modules, IComponentInfo[] components)
        {
            Name = name;
            Version = version;
            Modules = modules;
            Components = components;
        }

        public string Name { get; }

        public string Version { get; }

        public IReadOnlyList<IModuleInfo> Modules { get; }

        public IReadOnlyList<IComponentInfo> Components { get; }
    }
}