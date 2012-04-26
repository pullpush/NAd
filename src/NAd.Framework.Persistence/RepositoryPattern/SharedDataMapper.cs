using System;
using NAd.Framework.Persistence.Abstractions;

namespace NAd.Framework.Persistence.RepositoryPattern
{
    internal class SharedDataMapper : IDataMapper
    {
        private readonly IDataMapper mapper;

        public SharedDataMapper(IDataMapper mapper)
        {
            this.mapper = mapper;
        }

        public bool HasTransaction
        {
            get { return mapper.HasTransaction; }
        }

        public bool IsDisposed
        {
            get { return mapper.IsDisposed; }
        }

        public IQueryableRepository<T, TId> GetRepository<T, TId>() 
            where T : Entity<TId>
            where TId : struct
        {
            return mapper.GetRepository<T, TId>();
        }

        public void SubmitChanges()
        {
            mapper.SubmitChanges();
        }

        public void EnlistTransaction()
        {
            mapper.EnlistTransaction();
        }

        public void RollbackTransaction()
        {
            mapper.RollbackTransaction();
        }

        public void CommitTransaction()
        {
            mapper.CommitTransaction();
        }

        public object Get(Type entityType, object id, long version = -1)
        {
            return mapper.Get(entityType, id, version);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Ignored, since we don't own the actual data mapper
        }
    }
}