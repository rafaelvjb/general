using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesteIdentity.Startup))]
namespace TesteIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
