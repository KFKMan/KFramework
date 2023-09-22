namespace KFramework
{
    public interface IObjectAccessor<out T>
    {
        T? Get();
    }
}