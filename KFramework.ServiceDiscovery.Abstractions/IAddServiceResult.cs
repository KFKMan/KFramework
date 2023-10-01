using KFramework.Abstractions;

namespace KFramework.ServiceDiscovery.Abstractions
{
    public interface IAddServiceResult : IResult
    {
        public Dictionary<IEndpoint, IAddServicePerServiceResult> AddServiceResults { get; }
    }
}