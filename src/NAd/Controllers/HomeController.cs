using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

using NAd.UI.ViewModels;

namespace NAd.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            List<string> blogNames = new List<string>();
            blogNames.Add("KodefuGuru");
            blogNames.Add("PlatinumBay");

            ViewBag.BlogNames = blogNames;

            return View();
        }

        //Home/Owner/{blogName} get
        public JsonResult Owner(string blogName)
        {
            return Json(BlogOwner.Create(blogName), JsonRequestBehavior.AllowGet);
        }
    }
}
