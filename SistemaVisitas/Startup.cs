using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaVisitas.Startup))]
namespace SistemaVisitas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
