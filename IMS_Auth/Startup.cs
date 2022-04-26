using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IMS_Auth.Startup))]
namespace IMS_Auth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
