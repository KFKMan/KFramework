namespace KFramework.Extensions
{
    public static class ListExtensions
    {
        public static bool TryAdd<T>(this List<T> list,T item)
        {
            if (list.Contains(item))
            {
                return false;
            }
            list.Add(item);
            return true;
        }
    }
}