namespace KFramework.Abstractions
{
    public static class EndpointExtensions
    {
        public static string GetAddress(this IEndpoint Endpoint)
        {
            return $"{Endpoint.Host}:{Endpoint.Port}";
        }
    }
}