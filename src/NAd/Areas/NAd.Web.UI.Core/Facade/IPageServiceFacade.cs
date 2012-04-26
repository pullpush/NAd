using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NAd.Framework.Persistence.Abstractions.Model;

namespace NAd.Web.UI.Core.Facade
{
    public interface IPageServiceFacade : IRestServiceFacade<IPageModel>
    {
        /// <summary>
        /// Gets the Page Model object via the URL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        IPageModel GetPageByUrl(string url);
    }
}
