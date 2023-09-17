using Microsoft.Extensions.Configuration;

namespace KFramework
{
    public static class ConfigurationExtensions
    {
        public static K? TryGetOrNull<K>(this IConfiguration config,string key) where K : class
        {
            var k = config.GetValue<K>(key);
            if(k != null)
            {
                return k;
            }
            return null;
        }
    }

    public static class DictionaryExtensions
    {
        public static K? TryGetOrNull<T, K>(this Dictionary<T, K> dictionary, T key) where K : class where T : notnull
        {
            if (dictionary.TryGetValue(key, out var value)) { return value; }
            return null;
        }
    }

    public static class ArrayExtensions
    {
        public static bool IsNullOrEmpty<T>(this T[]? array)
        {
            if(array == null ||
                array.Length == 0)
            {
                return true;
            }
            return false;
        }
    }
}