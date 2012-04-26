using Autofac;

using NAd.Querying.Core.Persistency.Common;
using NAd.Querying.Core.Persistency.NHibernate;

namespace NAd.Querying.Core.Persistency
{
    public class NAdUnitOfWorkFactory : NHibernateUnitOfWorkFactory<NAdUnitOfWork>
    {
        public NAdUnitOfWorkFactory(ILifetimeScope lifetimeScope) : base(lifetimeScope)
        {
        }

        protected override NAdUnitOfWork CreateUnitOfWork(IDataMapper mapper)
        {
            return new NAdUnitOfWork(mapper);
        }
    }
}