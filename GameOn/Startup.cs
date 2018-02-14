//  --------------------------------------------------------------------------------------
// GameOn.Startup.cs
// 2018/02/14
//  --------------------------------------------------------------------------------------

using System.Web.Mvc;
using System.Web.Routing;
using GameOn;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace GameOn
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions
                                        {
                                            AuthenticationMode = AuthenticationMode.Active,
                                            CookieDomain = "GameOn",
                                            SlidingExpiration = true
                                        });
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}