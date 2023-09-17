using Microsoft.AspNetCore.Builder;

namespace KFramework.Integration.AspCore
{
    public static class KWebApplication
    {
        public static KAspApplicationBuilder CreateBuilder(this WebApplicationBuilder builder)
        {
            return new KAspApplicationBuilder(builder);
        }

        public static KAspApplicationBuilder CreateBuilder()
        {
            return WebApplication.CreateBuilder().CreateBuilder();
        }

        public static KAspApplicationBuilder CreateBuilder(string[] args)
        {
            return WebApplication.CreateBuilder(args).CreateBuilder();
        }

        public static KAspApplicationBuilder CreateBuilder(WebApplicationOptions options)
        {
            return WebApplication.CreateBuilder(options).CreateBuilder();
        }
    }
}