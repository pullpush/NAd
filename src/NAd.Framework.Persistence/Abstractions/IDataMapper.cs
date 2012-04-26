using System;
using NAd.Framework.Persistence.RepositoryPattern;

namespace NAd.Framework.Persistence.Abstractions
{
    public interface IDataMapper : IDisposable
    {
        bool HasTransaction { get; }
        bool IsDisposed { get; }
        IQueryableRepository<T, TId> GetRepository<T, TId>() 
            where T : Entity<TId>
            where TId : struct;
        void SubmitChanges();
        void EnlistTransaction();
        void RollbackTransaction();
        void CommitTransaction();

        object Get(Type entityType, object id, long version = -1); //VersionedEntity<TId>.IgnoredVersion
    }
}