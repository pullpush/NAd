using System.Linq;
using System.Text;
using NAd.Framework.Persistence.Abstractions;
using NAd.Framework.Persistence.Abstractions.Model;
using NHibernate;

namespace NAd.Framework.Persistence.NHibernate
{
    internal class NAdNHibernateRepository<T, TId> : NHibernateBaseRepository<T, TId>, IPageRepository<T, TId>
        where T : Entity<TId>
        where TId : struct 
    {
        public NAdNHibernateRepository(ISession session) : base(session) {
        }

        /// <summary>
        /// Get a page by the url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public IPageModel GetPageByUrl(string url)
        {
            return Entities
                .Where(x => x.Metadata.Url == url)
                .FirstOrDefault();
        }
    }
}
