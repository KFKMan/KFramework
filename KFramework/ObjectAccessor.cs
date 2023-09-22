namespace KFramework
{
    public class ObjectAccessor<T> : IObjectAccessor<T>
    {
        private T? Value { get; set; }

        public T? Get()
        {
            return Value;
        }

        public ObjectAccessor()
        {

        }

        public ObjectAccessor(T? obj)
        {
            Value = obj;
        }
    }
}