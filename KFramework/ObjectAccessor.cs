namespace KFramework
{
    public class ObjectAccessor<T> : IObjectAccessor<T>
    {
        public T? Value { get; set; }

        public ObjectAccessor()
        {

        }

        public ObjectAccessor(T? obj)
        {
            Value = obj;
        }
    }

    public class ExtendedObjectAccessorGetter<K, T> : IExtendedObjectAccessorGetter<K,T>
    {
        public Func<K,T?> Getter { get; set; }

        public ExtendedObjectAccessorGetter(Func<K,T?> getter)
        {
            Getter = getter;
        }

        public T? Get(K value)
        {
            return Getter(value);
        }
    }

    public class ExtendedObjectAccessor<K,T> : IObjectAccessor<T>
    {
        public ExtendedObjectAccessorGetter<K,T> Getter { get; set; }
        public K BaseValue { get; set; }

        public ExtendedObjectAccessor(ExtendedObjectAccessorGetter<K,T> getter,K basevalue)
        {
            Getter = getter;
            BaseValue = basevalue;
        }

        public T? Value
        {
            get
            {
                return Getter.Get(BaseValue);
            }
        }
    }
}