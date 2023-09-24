namespace KFramework.Abstractions
{
    public interface IObjectAccessor<out T>
    {
        T? Get();
    }
}