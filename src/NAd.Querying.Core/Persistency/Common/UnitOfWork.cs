using System;

namespace NAd.Querying.Core.Persistency.Common
{
    public abstract class UnitOfWork : IDisposable
    {
        private readonly IDataMapper mapper;

        protected UnitOfWork(IDataMapper mapper)
        {
            this.mapper = mapper;
        }

        public object Get(Type entityType, object id)
        {
            return mapper.Get(entityType, id);
        }

        public object Get(Type entityType, object id, long version)
        {
            return mapper.Get(entityType, id, version);
        }

        /// <summary>
        /// Enlists in an ambient transaction, or, if none is available, creates a new transaction.
        /// </summary>
        public void EnlistTransaction()
        {
            mapper.EnlistTransaction();
        }

        /// <summary>
        /// Flags the transaction as complete, and if no ambient transaction exists, commits the changes to the data store.
        /// </summary>
        public void CommitTransaction()
        {
            mapper.CommitTransaction();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (!Disposed)
            {
                mapper.Dispose();
                Disposed = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this unit of work has already been disposed.
        /// </summary>
        internal bool Disposed { get; set; }

        protected internal IDataMapper Mapper
        {
            get { return mapper; }
        }

        public void SubmitChanges()
        {
            mapper.SubmitChanges();
        }
    }
}