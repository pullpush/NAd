using System.Web.Mvc;
using NAd.Web.UI.Core.Web.Routing;

namespace NAd.Web.UI.Core
{
    public class CoreUIAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Gets the name of the area to register.
        /// </summary>
        /// <returns>The name of the area to register.</returns>
        public override string AreaName { get { return "Dashboard"; } }

        /// <summary>
        /// Registers an area in an ASP.NET MVC application using the specified area's context information.
        /// </summary>
        /// <param name="context">Encapsulates the information that is required in order to register the area.</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            ViewEngines.Engines.Add(new RazorViewEngine
            {
                AreaPartialViewLocationFormats = new[] { "~/Areas/NAd.Web.UI.Core/Views/{1}/{0}.cshtml", "~/Areas/BrickPile.UI/Views/Shared/{0}.cshtml" },
                AreaMasterLocationFormats = new[] { "~/Areas/NAd.Web.UI.Core/Views/{1}/{0}.cshtml" },
                AreaViewLocationFormats = new[] { "~/Areas/NAd.Web.UI.Core/Views/{1}/{0}.cshtml" }
            });

            //var dashboardRoute = new ContentRoute(
            //    ObjectFactory.GetInstance<DashboardPathResolver>(),
            //    ObjectFactory.GetInstance<DashboardVirtualPathResolver>(),
            //    null);

            //context.Routes.Add("Dashboard", dashboardRoute);

            context.MapRoute(
                "Dashboard_publish",
                "dashboard/content/publish/{id}/{published}",
                new { controller = "content", action = "publish", Area = "dashboard" }
            );

            context.MapRoute(
                "Dashboard_default",
                "dashboard/{controller}/{action}/{id}",
                new { controller = "dashboard", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}
