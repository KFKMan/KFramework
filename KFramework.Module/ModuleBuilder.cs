using KFramework.Extensions;
using KFramework.Module.Abstractions;

namespace KFramework.Module
{
    public class ModuleBuilder : IModuleBuilder
    {
        public ModuleBuilder()
        {

        }

        #region MainType
        private Type? MainType = null;

        public IModuleBuilder SetMainType(Type type)
        {
            MainType = type;
            return this;
        }
        #endregion

        #region Name
        public string? Name = null;

        public IModuleBuilder SetName(string name)
        {
            Name = name;
            return this;
        }
        #endregion

        #region Version
        public Version? Version = null;

        public IModuleBuilder SetVersion(Version version)
        {
            Version = version;
            return this;
        }
        #endregion

        public IModule Build()
        {
            var module = new Module();
            if(MainType != null)
            {
                module.MainType = MainType;
            }
            if(Name != null)
            {
                module.Name = Name;
            }
            if(Version != null)
            {
                module.Version = Version;
            }
            return module;
        }

        public object Clone()
        {
            var clone = this.MemberwiseClone();

            return clone;
        }
    }
}