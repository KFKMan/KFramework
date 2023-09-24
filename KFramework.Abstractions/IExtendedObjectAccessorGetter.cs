namespace KFramework.Abstractions
{
    public interface IExtendedObjectAccessorGetter<K, T>
    {
        T? Get(K value);
    }
}