using Microsoft.Extensions.DependencyInjection;
using KFramework;
using Microsoft.Extensions.Configuration;
using KFramework.Abstractions;

internal static class InternalServiceCollectionExtensions
{
    internal static void AddCoreServices(this IServiceCollection services)
    {
        services.AddOptions();
        services.AddLogging();
        services.AddLocalization();
    }

    internal static void AddCoreKServices(this IServiceCollection services,
        IKApplication kApplication
        //,AbpApplicationCreationOptions applicationCreationOptions
        )
    {
#warning TODO: Module System
    }
}