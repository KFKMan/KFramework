using System.Collections.Generic;

namespace KFramework.Module
{
    public class ComponentInfo
    {
        public ComponentInfo(string name, string type, IReadOnlyDictionary<string, object> properties)
        {
            Name = name;
            Type = type;
            Properties = properties;
        }

        public string Name { get; }

        public string Type { get; }

        public IReadOnlyDictionary<string, object> Properties { get; }
    }
}
