using System;
using System.Collections.Generic;

namespace KFramework.Module
{
    public class ModuleInfo
    {
        public ModuleInfo(string name, string version, ModuleInfo[] modules, ComponentInfo[] components)
        {
            Name = name;
            Version = version;
            Modules = modules;
            Components = components;
        }

        public string Name { get; }

        public string Version { get; }

        public IReadOnlyList<ModuleInfo> Modules { get; }

        public IReadOnlyList<ComponentInfo> Components { get; }
    }
}