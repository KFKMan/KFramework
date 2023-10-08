using Microsoft.Extensions.Configuration;

namespace KFramework.Extensions
{
    public static class ConfigurationExtensions
    {
        public static K? TryGetOrNull<K>(this IConfiguration config, string key) where K : class
        {
            var k = config.GetValue<K>(key);
            if (k != null)
            {
                return k;
            }
            return null;
        }
    }
}