using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFramework.Module.Abstractions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DependsOn : Attribute
    {
        public DependsOn(params Type[] types) 
        {
            Types = types;
        }

        public Type[] Types { get; }
    }
}
