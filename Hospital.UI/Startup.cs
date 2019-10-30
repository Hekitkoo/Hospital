using Hospital.UI;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Hospital.UI
{
    
    partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutofacConfig.RegisterAutofacModules(app);
            AuthConfig.ConfigureAuth(app);
        }
    }
}