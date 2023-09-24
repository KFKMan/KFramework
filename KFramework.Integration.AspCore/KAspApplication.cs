using KFramework.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KFramework.Integration.AspCore
{
    public class KAspApplication : KApplication
    {
        public KAspApplication(KApplicationSettings settings) : base(settings)
        {

        }
    }
}