using KFramework.Module.Abstractions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KFramework.Module
{
    public class ComponentInfo : IComponentInfo
    {
        public ComponentInfo(string name, string type, IReadOnlyDictionary<string, object>? properties)
        {
            Name = name;
            Type = type;
            Properties = properties ?? new Dictionary<string,object>();
        }

        public string Name { get; }

        public string Type { get; }

        public IReadOnlyDictionary<string, object> Properties { get; }
    }
}
