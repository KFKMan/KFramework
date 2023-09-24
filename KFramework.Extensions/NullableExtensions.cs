namespace KFramework.Extensions
{
    public static class NullableExtensions
    {
        public static T Return<T>(this T? value)
        {
            value.ThrowIfNull();
            return value!;
        }

        public static bool IsNotNull<T>(this T? value)
        {
            return !value.IsNull();
        }

        public static bool IsNull<T>(this T? value)
        {
            return value == null;
        }

        public static void ThrowIfNull<T>(this T? value)
        {
            if(value.IsNull())
            {
                throw new Exception("Value is null !");
            }
        }

        public static bool NullableAction<T>(this T? value,Action<T> action)
        {
            if(value.IsNotNull())
            {
                action(value!);
                return true;
            }
            return false;
        }

        public static X NullableActionWithReturn<T,X>(this T? value, Func<T, X> function,X? defaultvalue = default(X))
        {
            var state = NullableAction(value, function.AsAction(out var handler));
            if (state == false)
            {
                defaultvalue.Return();
            }
            return handler.Value!;
        }

        public static T DefaultIfNull<T>(this T? value,T? defaultvalue = default(T))
        {
            if(value != null)
            {
                return value!;
            }
            return defaultvalue.Return();
        }

        public static T DefaultIfNull<T>(this T? value, Func<T> function)
        {
            if (value != null)
            {
                return value!;
            }
            return function();
        }
    }
}