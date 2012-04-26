
using System.Linq;
//using BrickPile.Core.Infrastructure.Indexes;
using NAd.Cms.Domain.Model;
//using Raven.Client;

namespace NAd.Cms.Core.Repositories
{
    /// <summary>
    /// Page repository implementation of <see cref="IPageRepository" /> that provides support for basic operations for objects implementing <see cref="IPageModel" /> interface.
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class PageRepository : Repository<IPageModel>, IPageRepository {

        /*
        private readonly IDocumentSession _documentSession;

        /// <summary>
        /// Get a page by the url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public T GetPageByUrl<T>(string url) where T : IPageModel {
            return _documentSession.Query<T, Document_ByUrl>()
                .Customize(x => x.WaitForNonStaleResultsAsOfLastWrite())
                .Where(x => x.Metadata.Url == url)
                .FirstOrDefault();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageRepository" /> class.
        /// </summary>
        /// <param name="documentSession"></param>
        public PageRepository(IDocumentSession documentSession) : base(documentSession) {
            _documentSession = documentSession;
        }
        */
    }
}