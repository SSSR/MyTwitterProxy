using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitterProxy.Startup))]
namespace TwitterProxy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
