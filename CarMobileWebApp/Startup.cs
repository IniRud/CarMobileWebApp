using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarMobileWebApp.Startup))]
namespace CarMobileWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
