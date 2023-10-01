namespace KFramework.Abstractions
{
    public interface IEndpoint
    {
        public string Host { get; }
        public int Port { get; }
    }
}