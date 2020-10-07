using Microsoft.Owin;
using Owin;
using AGAT.LocoDispatcher.AuthData;
using AGAT.LocoDispatcher.AuthData.Managers;

[assembly: OwinStartup(typeof(AGAT.LocoDispatcher.WebAPI.App_Start.Startup))]
 
namespace AGAT.LocoDispatcher.WebAPI.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // настраиваем контекст и менеджер
            app.CreatePerOwinContext(AuthContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/Account/Login"),
            //});
        }
    }
}