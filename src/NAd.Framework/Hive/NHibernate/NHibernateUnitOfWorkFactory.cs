using Autofac;
using NAd.Framework.Persistence.Abstractions;
using NAd.Framework.Persistence.NHibernate;

namespace NAd.Framework.Hive.NHibernate
{
    public class NHibernateUnitOfWorkFactory : NHibernateUnitOfWorkFactory<NAdUnitOfWork>
    {
        public NHibernateUnitOfWorkFactory(ILifetimeScope lifetimeScope)
            : base(lifetimeScope)
        {
        }

        protected override NAdUnitOfWork CreateUnitOfWork(IDataMapper mapper)
        {
            return new NAdUnitOfWork(mapper);
        }
    }
}