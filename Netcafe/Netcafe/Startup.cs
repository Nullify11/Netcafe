using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Netcafe.Startup))]
namespace Netcafe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
