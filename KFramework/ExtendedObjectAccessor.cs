namespace KFramework
{
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