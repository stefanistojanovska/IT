using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeautifulDestinations2._0.Startup))]
namespace BeautifulDestinations2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
