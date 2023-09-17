namespace KFramework
{
    public interface IExtendedObjectAccessorGetter<K,T>
    {
        T? Get(K value);
    }
}