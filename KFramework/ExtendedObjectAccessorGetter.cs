using KFramework.Abstractions;

namespace KFramework
{
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
}