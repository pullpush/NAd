using System;

using NAd.Querying.Core.Domain;
using NAd.Querying.Core.Persistency.RepositoryPattern;

namespace NAd.Querying.Core.Persistency.Common
{
    public interface IDataMapper : IDisposable
    {
        bool HasTransaction { get; }
        bool IsDisposed { get; }
        Repository<T> GetRepository<T>() where T : class, IEntity;
        void SubmitChanges();
        void EnlistTransaction();
        void RollbackTransaction();
        void CommitTransaction();

        object Get(Type entityType, object id, long version = VersionedEntity.IgnoredVersion);
    }
}