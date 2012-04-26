
using System;
using System.Collections.Generic;
using System.Linq;
using NAd.Framework.Persistence.Abstractions;
using NAd.Framework.Persistence.Abstractions.Model;
using NAd.Framework.Persistence.RepositoryPattern;
using NUnit.Framework;

namespace NAd.Framework.Specs
{
    public class InMemoryDataMapper : IDataMapper
    {
        private readonly List<object> committed = new List<object>();
        private readonly List<object> uncommittedInserts = new List<object>();
        private readonly List<object> uncommittedDeletes = new List<object>();

        public InMemoryDataMapper()
        {
        }

        public InMemoryDataMapper(params object[] commitedEntities)
        {
            foreach (var commitedEntity in commitedEntities)
            {
                AddCommitted(commitedEntity);
            }
        }

        public void EnlistTransaction()
        {
            HasTransaction = true;
            IsTransactionCommited = false;
            IsTransactionRolledBack = false;
        }

        public void RollbackTransaction()
        {
            IsTransactionRolledBack = true;
        }

        public void CommitTransaction()
        {
            SubmitChanges();
            IsTransactionCommited = true;
        }

        public bool HasTransaction { get; set; }

        public bool Saved { get; private set; }
        public bool IsDisposed { get; private set; }

        public bool IsTransactionCommited { get; private set; }
        public bool IsTransactionRolledBack { get; private set; }

        public IEnumerable<T> GetCommittedEntities<T>() where T : class
        {
            return committed.OfType<T>();
        }

        public IEnumerable<T> GetUncommittedEntities<T>() where T : class
        {
            return uncommittedInserts.OfType<T>();
        }

        public IEnumerable<T> GetUncommittedDeletes<T>() where T : class
        {
            return uncommittedDeletes.OfType<T>();
        }

        public void AddCommitted(object entity)
        {
            committed.Add(entity);
        }

        public IQueryableRepository<T, TId> GetRepository<T, TId>()
            where T : Entity<TId>
            where TId : struct
        {
            return new InMemoryRepository<T, TId>(this);
        }

        public object Get(Type entityType, object id, long version = -1)    //VersionedEntity.IgnoredVersion
        {

            object entity = committed.Single(c =>
                (((IEntity<Guid>)c).Id.Equals(id)) && (c.GetType().Equals(entityType)));

            if (version != -1)  //VersionedEntity.IgnoredVersion
            {
                var versionedEntity = entity as IHaveVersion;
                if (versionedEntity == null)
                {
                    throw new InvalidOperationException(entityType.Name + " is not a versioned entity");
                }

                if (versionedEntity.Version != version)
                {
                    //throw new ApplicationErrorException(ServiceError.RecordIsChangedByAnotherUser);
                }
            }

            return entity;
        }

        public void SubmitChanges()
        {
            committed.AddRange(uncommittedInserts);
            uncommittedInserts.Clear();
            committed.RemoveAll(e => uncommittedDeletes.Contains(e));
            uncommittedDeletes.Clear();
            Saved = true;
        }

        public void Dispose()
        {
            IsDisposed = true;
        }

        private sealed class InMemoryRepository<T, TId> : AbstractRepository<T, TId>
            where T : Entity<TId>
            where TId : struct
        {
            private readonly InMemoryDataMapper mapper;

            public InMemoryRepository(InMemoryDataMapper mapper)
            {
                this.mapper = mapper;
            }

            protected override IQueryable<T> Entities
            {
                get { return mapper.committed.OfType<T>().AsQueryable(); }
            }

            public override void Add(T entity)
            {
                if (mapper.committed.Contains(entity))
                {
                    Assert.Fail("Entity already exist.");
                }

                mapper.uncommittedInserts.Add(entity);
            }

            public override void Remove(T entity)
            {
                if (!mapper.committed.Contains(entity))
                {
                    Assert.Fail("Entity does not exist.");
                }

                mapper.uncommittedDeletes.Add(entity);
            }

            public override T Get(TId id)
            {
                throw new NotImplementedException();
            }

            public override IPageModel GetPageByUrl(string url)
            {
                throw new NotImplementedException();
            }

            public override T Load(TId id)
            {
                throw new NotImplementedException();
            }

            public override void Update(T entity)
            {
                throw new NotImplementedException();
            }

            public override void Save(T entity)
            {
                throw new NotImplementedException();
            }
        }
    }
}