using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rentilla.Startup))]
namespace Rentilla
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
