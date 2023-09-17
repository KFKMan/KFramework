using Microsoft.Extensions.DependencyInjection;
using KFramework;
using Microsoft.Extensions.Configuration;

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
#warning Module Sistemi gelecek !
    }
}