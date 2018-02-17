//  --------------------------------------------------------------------------------------
// GameOn.Web.Startup.cs
// 2018/02/16
//  --------------------------------------------------------------------------------------

using System.Web.Mvc;
using System.Web.Routing;
using GameOn.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace GameOn.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}