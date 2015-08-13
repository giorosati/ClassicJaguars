using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClassicJaguars.Startup))]
namespace ClassicJaguars
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
