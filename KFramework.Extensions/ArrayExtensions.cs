namespace KFramework.Extensions
{

    public static class ArrayExtensions
    {
        public static bool IsNullOrEmpty<T>(this T[]? array)
        {
            if (array == null ||
                array.Length == 0)
            {
                return true;
            }
            return false;
        }
    }
}