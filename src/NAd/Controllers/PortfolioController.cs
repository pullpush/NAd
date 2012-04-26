
using System.Web.Mvc;
using NAd.Framework.Persistence.Abstractions.Model;
using NAd.UI.PageModels;
using NAd.UI.ViewModels;
using NAd.Web.UI.Core.Facade;

//using Raven.Client;

namespace NAd.UI.Controllers {
    /// <summary>
    /// 
    /// </summary>
    public class PortfolioController : BaseController<Portfolio> {

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            var model = new PortfolioViewModel
                            {
                                CurrentModel = this.CurrentModel,
                                Hierarchy = this.Hierarchy,
                                Class = "portfolio"
                            };
            return View(model);
        }


        ///// <param name="documentSession">The document session.</param>
        //public PortfolioController(IPageModel model, IDocumentSession documentSession)
        //    : base(model, documentSession) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioController"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="pageServiceFacade">The page service facade class.</param>
        public PortfolioController(IPageModel model, IPageServiceFacade pageServiceFacade)
            : base(model, pageServiceFacade) { }
    }
}
