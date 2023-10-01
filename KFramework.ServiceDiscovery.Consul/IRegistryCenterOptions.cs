namespace KFramework.ServiceDiscovery.Consul
{
    public interface IRegistryCenterOptions
    {
        string Type { get; }

        bool RegisterSwaggerDoc { get; set; }

    }
}