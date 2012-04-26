
using System;
using System.Collections.Generic;
using System.Linq;
using NAd.Framework.Persistence.Abstractions;
using NAd.Framework.Persistence.Abstractions.Model;
using NAd.Framework.Persistence.RepositoryPattern;
using NAd.Framework.Domain.Raven;
using Raven.Client;
using Raven.Client.Document;

namespace NAd.Framework.Persistence.Raven
{
    //AI: check this Raven implementation
    //http://www.primaryobjects.com/CMS/Article125.aspx

    internal class RavenBaseRepository<T, TId> : AbstractRepository<T, TId>, IRavenRepository<T, TId>//, IPageRepository<T, TId>
        where T : Entity<TId>
        where TId : struct
    {
        //private IQueryable<T> queryable;

        //IDocumentStore - This is expensive to create, thread safe and should only be created once per application.
        //readonly IDocumentStore _documentStore;
        readonly IDocumentSession _documentSession;
        //private IDocumentSession _context;

        /// <summary>
        /// Instances of this interface are created by the DocumentStore, they 
        /// are cheap to create and are not thread safe. If an exception is thrown by any IDocumentSession method, 
        /// the behavior of all of the methods (except Dispose) is undefined. 
        /// The document session is used to interact with the Raven database, 
        /// load data from the database, query the database, save and delete. 
        /// Instances of this interface implement the Unit of Work pattern and change tracking. 
        /// </summary>
        /// <param name="documentSession"></param>
        public RavenBaseRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        protected override IQueryable<T> Entities
        {
            get
            {
                //queryable = _documentSession.Query<T>();
                return _documentSession.Query<T>();
            }
        }

        /// <summary>
        /// Loads the specified ids.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public override T Load(TId id)
        {
            return _documentSession.Load<T>(id.ToString());
        }

        /// <summary>
        /// Fetches an entity of type <typeparamref name="T"/> by Id
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        public override T Get(TId id)
        {
            return _documentSession.Load<T>(id);

            //string ids = id.ToString();

            //return Entities.Where(e => e.Id.Equals(ids)).SingleOrDefault();

           // return Entities.Where(e => ((IComparable<TId>)e.Id).CompareTo(id) == 0).SingleOrDefault();
           // return Entities.Where(e => e.Id.CompareTo(id)).SingleOrDefault();
           // return Entities.Where(e => e.Id.Equals(id)).SingleOrDefault();
        }

        //public override T GetById(TId id)
        //{
        //    return Entities.Where(e => e.Id.Equals(id)).SingleOrDefault();
        //}

        /// <summary>
        /// To save an entity. This will perform an Insert or Update
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(T entity)
        {
            _documentSession.Store(entity);
        }

        public override void Add(T entity)
        {
            _documentSession.Store(entity);
        }

        public override void Update(T entity)
        {
            _documentSession.SaveChanges();
        }

        /// <summary>
        /// To delete an entity
        /// </summary>
        /// <param name="entity"></param>
        public override void Remove(T entity)
        {
            _documentSession.Delete(entity);
        }


        #region Raven repository specific custom methods

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> List()
        {
            return _documentSession.Query<T>()
                .Customize(x => x.WaitForNonStaleResultsAsOfLastWrite());
        }


        /// <summary>
        /// Refreshes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Refresh(T entity)
        {
            _documentSession.Advanced.Refresh(entity);
        }


        /// <summary>
        /// Get a page by the url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public override IPageModel GetPageByUrl(string url)
        {
            return _documentSession.Query<T, Page_ByUrl>()
                .Customize(x => x.WaitForNonStaleResultsAsOfLastWrite())
                .Where(x => x.Metadata.Url == url)
                .FirstOrDefault();
        }

        #endregion
    }
}
