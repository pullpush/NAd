using System.Web.Mvc;

namespace NAd.UI.Areas.core
{
    public class coreAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "core";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "core_default",
                "core/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
