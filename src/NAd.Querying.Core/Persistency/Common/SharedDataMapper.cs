using System;

using NAd.Querying.Core.Domain;
using NAd.Querying.Core.Persistency.RepositoryPattern;

namespace NAd.Querying.Core.Persistency.Common
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

        public Repository<T> GetRepository<T>() where T : class, IEntity
        {
            return mapper.GetRepository<T>();
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