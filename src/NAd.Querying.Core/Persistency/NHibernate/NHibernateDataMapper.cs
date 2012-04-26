using System;
using System.Collections.Generic;

using NAd.Common;
using NAd.Querying.Core.Domain;
using NAd.Querying.Core.ExceptionHandling;
using NAd.Querying.Core.Persistency.Common;
using NAd.Querying.Core.Persistency.RepositoryPattern;
using NHibernate;
using NHibernate.Criterion;

namespace NAd.Querying.Core.Persistency.NHibernate
{
    public class NHibernateDataMapper : IDataMapper
    {
        private ISession session;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private ITransaction transaction;

        public NHibernateDataMapper(ISession session)
        {
            this.session = session;
        }

        public bool HasTransaction
        {
            get { return (transaction != null); }
        }

        public bool IsDisposed
        {
            get { return session == null; }
        }

        public ISession Session
        {
            get { return session; }
        }

        public Repository<T> GetRepository<T>() where T : class, IEntity
        {
            object repository;
            if (!repositories.TryGetValue(typeof (T), out repository))
            {
                repository = new NHibernateRepository<T>(session);
                repositories[typeof (T)] = repository;
            }
            
            return (Repository<T>)repository;
        }

        /// <summary>
        /// Gets the entity with the specified id and optionally verifies that it has not been changed by somebody else.
        /// </summary>
        public object Get(Type entityType, object id, long version = VersionedEntity.IgnoredVersion)
        {
            var entity = session.CreateCriteria(entityType)
                .Add(Restrictions.Eq(DatabaseConstants.IdentityColumn, id))
                .UniqueResult();

            if (entity == null)
            {
                throw new ApplicationErrorException(ServiceError.RecordDoesNotExistAnymore)
                {
                    { "Entity",  entityType.Name}
                };

            }

            if (version != VersionedEntity.IgnoredVersion)
            {
                var versionedEntity = entity as IHaveVersion;
                if (versionedEntity == null)
                {
                    throw new InvalidOperationException(entityType.Name + " is not a versioned entity");
                }

                if (versionedEntity.Version != version)
                {
                    throw new ApplicationErrorException(ServiceError.RecordIsChangedByAnotherUser);
                }
            }

            return entity;
        }

        public void EnlistTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void CommitTransaction()
        {
            transaction.Commit();
            transaction = null;
        }

        public void RollbackTransaction()
        {
            transaction.Rollback();
        }

        public void SubmitChanges()
        {
            session.Flush();
        }

        public void Dispose()
        {
            if (session != null)
            {
                session.Dispose();
                session = null;
            }
        }
    }
}