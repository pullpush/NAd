using Autofac;
using NAd.Framework.Persistence.Abstractions;
using ISession = NHibernate.ISession;

namespace NAd.Framework.Persistence.NHibernate
{
    public abstract class NHibernateUnitOfWorkFactory<TUnitOfWork> : UnitOfWorkFactory<TUnitOfWork>
        where TUnitOfWork : UnitOfWork
    {
        private readonly ILifetimeScope lifetimeScope;

        protected NHibernateUnitOfWorkFactory(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        /// <summary>
        /// Creates the data mapper.
        /// </summary>
        /// <returns></returns>
        protected override IDataMapper CreateDataMapper()
        {
            var session = lifetimeScope.ResolveKeyed<ISession>(typeof (TUnitOfWork));

            return new NHibernateDataMapper(session);
        }
    }
}