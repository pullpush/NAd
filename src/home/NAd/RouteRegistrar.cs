using System.Web.Mvc;
using System.Web.Routing;

namespace NAd.UI
{
    public class RouteRegistrar
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
               "Default",
               "{controller}/{action}/{id}",
               new { controller = "Home", action = "Index", id = "" }
               );
        }
    }
}