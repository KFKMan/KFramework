namespace KFramework.Extensions
{
    public static class BoolExtensions
    {
        #region With Self Value
        public static X IfNotNull<A, X>(this A? value, Func<A,X> function, X? defaultvalue = default(X))
        {
            return value.If((Y) => Y.IsNotNull(), function!, defaultvalue);
        }

        public static X IfNull<A, X>(this A? value, Func<A?,X> function, X? defaultvalue = default(X))
        {
            return value.If((Y) => Y.IsNull(), function!, defaultvalue);
        }

        //it's needed?
        public static X IfFalse<X>(this bool state, Func<bool,X> function, X? defaultvalue = default(X))
        {
            return state.If(false.CreateSimpleFunc(), function, defaultvalue);
        }

        //it's needed?
        public static X IfTrue<X>(this bool state, Func<bool,X> function, X? defaultvalue = default(X))
        {
            return state.If(true.CreateSimpleFunc(), function, defaultvalue);
        }

        public static X If<Y, X>(this Y state, Func<Y, bool> predicate, Func<Y,X> function, X? defaultvalue = default(X))
        {
            if (predicate(state))
            {
                return function(state);
            }
            defaultvalue.ThrowIfNull();
            return defaultvalue!;
        }
        #endregion

        #region Without Self Value
        public static X IfNotNull<A,X>(this A? value, Func<X> function, X? defaultvalue = default(X))
        {
            return value.If((Y) => Y.IsNotNull(), function, defaultvalue);
        }

        public static X IfNull<A, X>(this A? value, Func<X> function, X? defaultvalue = default(X))
        {
            return value.If((Y) => Y.IsNull(), function, defaultvalue);
        }

        public static X IfFalse<X>(this bool state,Func<X> function, X? defaultvalue = default(X))
        {
            return state.If(false.CreateSimpleFunc(), function, defaultvalue);
        }

        public static X IfTrue<X>(this bool state, Func<X> function, X? defaultvalue = default(X))
        {
            return state.If(true.CreateSimpleFunc(), function, defaultvalue);
        }

        public static X If<Y,X>(this Y state,Func<Y,bool> predicate,Func<X> function,X? defaultvalue=default(X))
        {
            if (predicate(state))
            {
                return function();
            }
            defaultvalue.ThrowIfNull();
            return defaultvalue!;
        }
        #endregion

        public static Func<bool, bool> CreateSimpleFunc(this bool comparevalue)
        {
            return (X) => X == comparevalue;
        }
    }
}