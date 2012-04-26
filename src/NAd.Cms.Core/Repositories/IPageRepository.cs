
using System.Collections.Generic;

namespace NAd.Cms.Core.Repositories
{
    public interface IPageRepository : IRepository<IPageModel> {
        /// <summary>
        /// Bies the URL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        //T GetPageByUrl<T>(string url) where T : IPageModel;
    }
}