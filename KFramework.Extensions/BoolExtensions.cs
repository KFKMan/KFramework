using System.Diagnostics;

namespace KFramework.Extensions
{
    public static class BoolExtensions
    {
        public static Func<bool, bool> CreateSimpleFunc(this bool comparevalue)
        {
            return (X) => X == comparevalue;
        }
    }
}