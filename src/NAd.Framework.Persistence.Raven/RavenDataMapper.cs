using System;
using System.Collections.Generic;
using NAd.Framework.Persistence.Abstractions;
using NAd.Framework.Persistence.RepositoryPattern;
using Raven.Client;

namespace NAd.Framework.Persistence.Raven
{
    public class RavenDataMapper : IDataMapper
    {
        private IDocumentSession session;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public RavenDataMapper(IDocumentSession session)
        {
            this.session = session;
        }

        #region IDataMapper Members

        public bool HasTransaction
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsDisposed
        {
            get { return session == null; }
        }

        public IQueryableRepository<T, TId> GetRepository<T, TId>()
            where T : Entity<TId>
            where TId : struct
        {
            object repository;
            //IRepository<T, TId> repository;
            if (!repositories.TryGetValue(typeof(T), out repository))
            {
                repository = new RavenBaseRepository<T, TId>(session);
                repositories[typeof(T)] = repository;
            }

            //return (AbstractRepository<T, TId>)repository;
            return (IQueryableRepository<T, TId>)repository;
        }

        public void SubmitChanges()
        {
            session.SaveChanges();
        }

        public void EnlistTransaction()
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public object Get(Type entityType, object id, long version = -1)
        {
            throw new NotImplementedException();

            //var entity = session.Load(id.ToString());

            //if (entity == null)
            //{
            //    //throw new ApplicationErrorException(ServiceError.RecordDoesNotExistAnymore)
            //    //{
            //    //    { "Entity",  entityType.Name}
            //    //};

            //}

            //if (version != -1)  //VersionedEntity.IgnoredVersion
            //{
            //    var versionedEntity = entity as IHaveVersion;
            //    if (versionedEntity == null)
            //    {
            //        throw new InvalidOperationException(entityType.Name + " is not a versioned entity");
            //    }

            //    if (versionedEntity.Version != version)
            //    {
            //        throw new ApplicationErrorException(ServiceError.RecordIsChangedByAnotherUser);
            //    }
            //}

            //return entity;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (session != null)
            {
                session.Dispose();
                session = null;
            }

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
