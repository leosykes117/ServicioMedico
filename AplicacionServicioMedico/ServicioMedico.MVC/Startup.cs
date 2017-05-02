using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServicioMedico.MVC.Startup))]
namespace ServicioMedico.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
