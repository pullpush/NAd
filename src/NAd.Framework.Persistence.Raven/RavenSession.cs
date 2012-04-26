using System;
using System.Collections.Generic;
using System.Linq;
using NAd.Framework.Persistence.Abstractions;
using Raven.Client;
using Raven.Client.Document;

namespace NAd.Framework.Persistence.Raven
{
    /*
    internal class RavenSession : ISession
    {
        readonly DocumentStore _documentStore;
        readonly IDocumentSession _documentSession;

        internal RavenSession()
        {
            _documentStore = new DocumentStore { Url = "http://localhost:8080" };
            _documentSession = _documentStore.Initialize().OpenSession();
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : Entity
        {
            // may need to take indexing into consideration. raven will generat temps for us, but that may not be so efficient.
            // * i don't even know how long the temps stick around for. Raven will try and optimize for us best it can. 
            return _documentSession.Query<TEntity>();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : Entity
        {
            _documentSession.Store(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            _documentSession.Store(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            _documentSession.Delete(entity);
        }

        public void SaveChanges()
        {
            _documentSession.SaveChanges();
        }

        public void Dispose()
        {
            _documentStore.Dispose();
            _documentSession.Dispose();
        }

        #region Future Load Methods. Can't use now because Raven forces Id's to be strings. If were not for that, we could make this generic between nHibernate and RavenDb.

        public TEntity Load<TEntity, TId>(TId id) where TEntity : Entity<TId>
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Load<TEntity, TId>(IEnumerable<TId> ids) where TEntity : Entity<TId>
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    */
}
