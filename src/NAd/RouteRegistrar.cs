using System.Web.Mvc;
using System.Web.Routing;
using System.ServiceModel.Activation;

using Ncqrs.CommandService;

namespace NAd.UI
{
    public class RouteRegistrar
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{Content}/{*pathInfo}");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            //routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Classifieds", // Route name
                "classifieds/{action}/{id}", // URL with parameters
                new { controller = "Classified", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );

            routes.MapRoute(
               "Default",
               "{controller}/{action}/{id}",
               new { controller = "Home", action = "Index", id = "" }
               );

            routes.MapRoute(
                "Owner",
                "Home/Owner/{blogName}",
                new { controller = "Home", action = "Owner", blogName = "" }
                );

            //routes.Add(new ServiceRoute("CommandService", new ServiceHostFactory(), typeof(CommandWebService)));
        }
    }
}