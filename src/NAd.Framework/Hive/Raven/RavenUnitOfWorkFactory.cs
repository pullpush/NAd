using Autofac;
using NAd.Framework.Persistence.Abstractions;
using NAd.Framework.Persistence.Raven;

namespace NAd.Framework.Hive.Raven
{
    public class RavenUnitOfWorkFactory : RavenUnitOfWorkFactory<NAdUnitOfWork>
    {
        public RavenUnitOfWorkFactory(ILifetimeScope lifetimeScope)
            : base(lifetimeScope)
        {
        }

        protected override NAdUnitOfWork CreateUnitOfWork(IDataMapper mapper)
        {
            return new NAdUnitOfWork(mapper);
        }
    }
}