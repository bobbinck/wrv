using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rv3.Startup))]
namespace rv3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
