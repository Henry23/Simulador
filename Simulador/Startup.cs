using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Simulador.Startup))]
namespace Simulador
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
