using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Appartments_MVC_Course.Startup))]
namespace Appartments_MVC_Course
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
