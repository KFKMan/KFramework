namespace KFramework.Extensions
{
    public static class DictionaryExtensions
    {
        public static K? TryGetOrNull<T, K>(this Dictionary<T, K> dictionary, T key) where K : class where T : notnull
        {
            if (dictionary.TryGetValue(key, out var value)) { return value; }
            return null;
        }
    }
}