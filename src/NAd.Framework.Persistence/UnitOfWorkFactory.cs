using System.Runtime.Remoting.Messaging;
using NAd.Framework.Persistence.Abstractions;
using NAd.Framework.Persistence.RepositoryPattern;

namespace NAd.Framework.Persistence
{
    public abstract class UnitOfWorkFactory<TUnitOfWork> : IUnitOfWorkFactory<TUnitOfWork> where TUnitOfWork : UnitOfWork
    {
        private readonly string ContextKey;

        protected UnitOfWorkFactory()
        {
            ContextKey = GetType().FullName;
        }

        public TUnitOfWork Create()
        {
            IDataMapper mapper = Current;
            if ((mapper != null) && !mapper.IsDisposed)
            {
                mapper = new SharedDataMapper(mapper);
            }
            else
            {
                mapper = CreateDataMapper();
                Current = mapper;
            }

            return CreateUnitOfWork(mapper);
        }

        protected abstract IDataMapper CreateDataMapper();

        protected abstract TUnitOfWork CreateUnitOfWork(IDataMapper mapper);

        private IDataMapper Current
        {
            get { return CallContext.GetData(ContextKey) as IDataMapper; }
            set { CallContext.SetData(ContextKey, value); }
        }
    }
}