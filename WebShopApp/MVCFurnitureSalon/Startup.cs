using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCFurnitureSalon.Startup))]
namespace MVCFurnitureSalon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "21345678908765432",
                LoginPath = new PathString("/Authorization/Login")
            });
        }
    }
}
