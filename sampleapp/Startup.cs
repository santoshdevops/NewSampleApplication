using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sampleapp.Startup))]
namespace sampleapp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
