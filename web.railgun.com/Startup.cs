using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(web.railgun.com.Startup))]
namespace web.railgun.com
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
