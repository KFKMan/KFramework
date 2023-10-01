namespace KFramework.Abstractions
{
    public class DefaultEndpoint : IEndpoint
    {
        public string Host { get; set; } = "";
        public int Port { get; set; } = 80;
    }
}