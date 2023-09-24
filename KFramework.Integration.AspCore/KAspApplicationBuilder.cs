using Microsoft.AspNetCore.Builder;

namespace KFramework.Integration.AspCore
{
    public class KAspApplicationBuilder
    {
        private WebApplicationBuilder Builder;

        public KAspApplicationBuilder(WebApplicationBuilder applicationbuilder)
        {
            Builder = applicationbuilder;
        }

        public List<KAspApplication> Applications = new();

        public KAspApplication CreateApp()
        {
            var app = new KAspApplication(new KAspApplicationSettings().SetStartupModuleType(typeof(KAspApplicationBuilder)).SetServiceCollection(Builder.Services).SetConfigurationBuilder(Builder.Configuration));
            Applications.Add(app);
            return app;
        }
    }
}