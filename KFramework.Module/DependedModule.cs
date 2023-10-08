using KFramework.Module.Abstractions;

namespace KFramework.Module
{
    public class DependedModule : ICloneable
    {
        public DependedModule(IModule module, List<Type> implements, List<Type> dependencies)
        {
            Module = module;
            Implements = implements;
            Dependencies = dependencies;
        }

        public IModule Module { get; private set; }
        public List<Type> Dependencies {get; private set; }
        public List<Type> Implements { get; private set; }

        public object Clone()
        {
            var me = (DependedModule)this.MemberwiseClone();
            me.Implements = Implements.ToList();
            return me;
        }
    }
}