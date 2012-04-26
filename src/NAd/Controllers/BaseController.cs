
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NAd.Framework.Persistence.Abstractions.Model;
using NAd.Web.UI.Core.Facade;

//using BrickPile.Core.Infrastructure.Common;
//using BrickPile.Domain.Models;
//using Raven.Client;

namespace NAd.UI.Controllers {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseController<T> : Controller where T : IPageModel {
        /// <summary>
        /// Base controller with Current model and a default hierarchy for navigational purpose
        /// </summary>
        private IEnumerable<IPageModel> _hierarchy;
        
        /// <summary>
        /// Gets the current model.
        /// </summary>
        public T CurrentModel { get; private set; }
        
        /// <summary>
        /// Gets the document session.
        /// </summary>
        //public IDocumentSession DocumentSession { get; private set; }
        public IPageServiceFacade PageServiceFacade { get; private set; }

        /// <summary>
        /// Gets the hierarchy
        /// </summary>
        public virtual IEnumerable<IPageModel> Hierarchy {
            get
            {
                throw new NotImplementedException();
                //return _hierarchy
                //       ?? (_hierarchy = DocumentSession.HierarchyFrom<IPageModel>(x => x.Id == CurrentModel.Id)
                //                            .Where(x => x.Metadata.IsPublished)
                //                            .Where(x => x.Metadata.DisplayInMenu)
                //                            .OrderBy(x => x.Metadata.SortOrder));
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="documentSession">The document session.</param>
        protected BaseController(IPageModel model, IPageServiceFacade pageServiceFacade)
        {
            CurrentModel = (T)model;
            PageServiceFacade = pageServiceFacade;
        }
    }
}
