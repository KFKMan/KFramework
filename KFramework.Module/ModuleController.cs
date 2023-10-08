using KFramework.Extensions;
using KFramework.Module.Abstractions;
using System.Reflection;

namespace KFramework.Module
{
    public class ModuleController
    {
        private List<IModule> Modules = new();
        private List<DependedModule> DependedModules = new();

        private List<DependedModule> Cache = new();
        private List<IModule> StartList = new();

        public bool IsInited { get; private set; } = false;
        public bool IsIniting { get; private set; } = false;


        public ModuleController(ModuleControllerOptions options)
        {
            Options = options;
        }

        public ModuleController()
        {

        }

        private void CreateCache()
        {
            Cache = DependedModules.Select(x => (DependedModule)x.Clone()).ToList();
        }

        public ModuleControllerOptions Options { get; set; } = new();

        private void ControlState()
        {
            if (IsInited)
            {
                if (Options.DisableChangesAfterInit)
                {
                    throw new Exception($"{nameof(ModuleController)} is inited and {nameof(Options.DisableChangesAfterInit)} option is enabled. You can't do change, this class already inited!");
                }
                else
                {
                    IsInited = false;
                }
            }
            else if(IsIniting)
            {
                if (Options.DisableChangesOnIniting)
                {
                    throw new Exception($"{nameof(ModuleController)} is initing and {nameof(Options.DisableChangesOnIniting)} option is enabled. You can't do change, this class initing!");
                }
            }
        }

        public ModuleController AddModule(IModule module)
        {
            ControlState();

            if (Options.UseDependsOnSystem)
            {
                var moduletype = module.GetType();
                var dependencies = moduletype.GetCustomAttributes<DependsOn>();
                var dependencieslist = dependencies.SelectMany(x => x.Types).ToList();
                List<Type> implements = new();
                implements.AddRange(module.Implements);
                implements.TryAdd(moduletype);
                if (Options.UseReflectionBasedImplementionDetection)
                {
                    var interfaces = moduletype.GetInterfaces().ToList();
                    interfaces.Remove(typeof(IDisposable));
                    interfaces.Remove(typeof(ICloneable));
                    interfaces.Remove(typeof(IComparable));
                    interfaces.Remove(typeof(IAsyncDisposable));
                    implements.AddRange(interfaces);
                    //needs more like this
                }
                var depmodule = new DependedModule(module,implements,dependencieslist);
                DependedModules.Add(depmodule);
            }

            Modules.Add(module);

            return this;
        }

        public ModuleController Init()
        {
            if(IsIniting || IsInited)
            {
                throw new Exception($"{nameof(ModuleController)} is already initing or inited!");
            }
            IsIniting = true;
            if (StartList.Any())
            {
                StartList.Clear();
            }
            if (Cache.Any())
            {
                Cache.Clear();
            }
            CreateCache();

            List<Type> implements = new();
            List<Type> tochange = new();

            int lastCount = Cache.Count;
            while (Cache.Count != 0)
            {
                var nodependencymodules = Cache.Where(x => x.Dependencies.Count == 0).ToList();
                foreach (var module in nodependencymodules)
                {
                    StartList.Add(module.Module);
                    implements.AddRange(module.Implements);
                    Cache.Remove(module);
                }
                foreach (var implement in implements)
                {
                    var dependeds = Cache.Where(x => x.Implements.Contains(implement)).ToList();
                    foreach (var doimplement in dependeds)
                    {
                        doimplement.Dependencies.Remove(implement);
                    }
                }
                if(lastCount == Cache.Count && Cache.Count != 0) //last line is not needed
                {
                    IsIniting = false;
                    throw new Exception("One or more dependend module can't loaded !");
                }
            }

            IsInited = true;
            IsIniting = false;
            return this;
        }
    }
}