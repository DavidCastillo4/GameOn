//  --------------------------------------------------------------------------------------
// GameOn.Web.Startup.cs
// 2018/02/16
//  --------------------------------------------------------------------------------------

using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using GameOn.Repository;
using GameOn.Web;
using GameOn.Web.Infrastructure;
using GameOn.Web.Models;
using GameOn.Web.ViewModel;
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
            var container = ConfigureDependencyInjection();
            app.UseAutofacMiddleware(container);

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        ILifetimeScope ConfigureDependencyInjection()
        {
            // Create DI Container
            var builder = new ContainerBuilder();

            // Register all MVC controllers
            builder.RegisterControllers(typeof(Startup).Assembly);

            // Register our custom types
            builder.RegisterType<InMemoryRepository>().As<IRepository>();
            builder.RegisterType<BrowseViewModel>();
            builder.RegisterType<ProductSummaryViewModel>();
            builder.RegisterType<AddToCartViewModel>();
            builder.RegisterType<CartItem>();
            builder.RegisterType<CartListItemViewModel>();
            builder.RegisterType<CartViewModel>();
            builder.RegisterType<CartCalculator>();
            builder.RegisterType<CartSerializer>();
            builder.RegisterType<CartRepository>();

            // Build the container so we can use it
            var container = builder.Build();

            // Set the DependencyResolver so that ASP.NET knows how to resolve
            // dependencies from the container.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return container;
        }
    }
}