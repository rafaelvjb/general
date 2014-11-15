using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleArch.Startup))]
namespace SampleArch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
