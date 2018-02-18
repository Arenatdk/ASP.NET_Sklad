using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sklad.Startup))]
namespace Sklad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
