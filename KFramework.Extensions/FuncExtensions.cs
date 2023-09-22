namespace KFramework.Extensions
{
    public static class FuncExtensions
    {
        // Need Template Code Generator !
        public static Action<T> AsAction<T,X>(this Func<T,X> function,out FuncHandler<T,X> handler)
        {
            handler = new FuncHandler<T, X>(function);
            return handler.GetAction();
        }
    }


    // Need Template Code Generator !
    public class FuncHandler<T,X>(Func<T,X> Function)
    {
        public X? Value = default(X);

        public Action<T> GetAction()
        {
            return (T) =>
            {
                Value = Function(T);
            };
        }
    }
}