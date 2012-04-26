using System.Linq;

using NAd.Querying.Core.Domain;
using NAd.Querying.Core.Persistency.RepositoryPattern;

using NHibernate;
using NHibernate.Linq;

namespace NAd.Querying.Core.Persistency.NHibernate
{
    internal class NHibernateRepository<T> : Repository<T> where T : class, IEntity
    {
        private readonly ISession session;
        private IQueryable<T> queryable;
        private ISession originalSession;

        public NHibernateRepository(ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Provides access to the repository-specific LINQ-enabled NHibernate collection.
        /// Fetches an <seealso cref="IQueryable"/> list of entities of type <typeparamref name="T"/>
        /// </summary>
        /// <remarks>
        ///   <typeparam name = "T">The entity type</typeparam>
        /// </remarks>
        protected override IQueryable<T> Entities
        {
            get
            {
                // In cases that a reference to a repositoy is maintained over multiple post-backs, the session belonging to the
                // queryable will be invalid (closed). This results in an exception when performing queries on the queryable.
                // This behaviour is caused by keeping the queryable in a variable. To workaround this problem, we create a new
                // queryable when the current session is a different one that we originally created the queryable with.
                if ((queryable == null) || (originalSession != session))
                {
                    originalSession = session;
                    queryable = session.Query<T>();
                }

                return queryable;
            }
        }

        /// <summary>
        ///  Loads the specified entity of type <typeparamref name="T"/> by Id. 
        ///  Throws an exception if not in database.
        /// </summary>
        /// <remarks>
        /// For invalid ids, Get returns null, and Load returns a proxy but throws when you access properties or save.
        /// Generally Get is more useful, but Load is useful when you know the id is valid and want lazy loading, 
        /// or just to set an association without an extra sql select.
        /// </remarks>
        /// <typeparam name="T">The entity type</typeparam>
        public override T Load(object id)
        {
            return session.Load<T>(id);
        }

        /// <summary>
        /// Fetches an entity of type <typeparamref name="T"/> by Id
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        public override T Get(object id)
        {
            return session.Get<T>(id);
        }

        /// <summary>
        /// To save an entity. This will perform an Insert or Update
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(T entity)
        {
            session.Save(entity);
        }

        /// <summary>
        /// To delete an entity
        /// </summary>
        /// <param name="entity"></param>
        public override void Remove(T entity)
        {
            session.Delete(entity);
        }       
    }
}