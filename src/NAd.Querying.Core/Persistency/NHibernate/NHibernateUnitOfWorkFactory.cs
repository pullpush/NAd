using Autofac;

using NAd.Querying.Core.Persistency.Common;

using NHibernate;

namespace NAd.Querying.Core.Persistency.NHibernate
{
    public abstract class NHibernateUnitOfWorkFactory<TUnitOfWork> : UnitOfWorkFactory<TUnitOfWork>
        where TUnitOfWork : UnitOfWork
    {
        #region Private Definitions

        private readonly ILifetimeScope lifetimeScope;

        #endregion

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