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
            var app = new KAspApplication(typeof(KAspApplicationBuilder), Builder.Services, configurationBuilder: Builder.Configuration);
            Applications.Add(app);
            return app;
        }
    }
}