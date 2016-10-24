using System.Web.Mvc;
using System.Web.Routing;

namespace Oxagile.Internal.IoC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Test", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}