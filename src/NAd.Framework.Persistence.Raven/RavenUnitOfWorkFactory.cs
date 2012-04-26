using System;
using Autofac;
using NAd.Framework.Persistence.Abstractions;
using Raven.Client;

namespace NAd.Framework.Persistence.Raven
{
    public class RavenUnitOfWorkFactory
    {
    }

    public abstract class RavenUnitOfWorkFactory<TUnitOfWork> : UnitOfWorkFactory<TUnitOfWork>
        where TUnitOfWork : UnitOfWork
    {
        #region Private Definitions

        private readonly ILifetimeScope lifetimeScope;

        #endregion

        protected RavenUnitOfWorkFactory(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        /// <summary>
        /// Creates the data mapper.
        /// </summary>
        /// <returns></returns>
        protected override IDataMapper CreateDataMapper()
        {
            var documentSession = lifetimeScope.ResolveKeyed<IDocumentSession>(typeof(TUnitOfWork));

            return new RavenDataMapper(documentSession);

            //var documentStore = lifetimeScope.ResolveKeyed<IDocumentStore>(typeof(TUnitOfWork));

            //return new RavenDataMapper(documentStore.OpenSession());
        }
    }
}
