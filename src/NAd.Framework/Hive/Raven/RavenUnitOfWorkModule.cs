using Autofac;
using AbstractRaven=NAd.Framework.Persistence.Raven;
using NAd.Framework.Services;

namespace NAd.Framework.Hive.Raven
{
    public class RavenUnitOfWorkModule : AbstractRaven.RavenUnitOfWorkModule<NAdUnitOfWork>
    {
        public RavenUnitOfWorkModule(string connectionStringName)
            : base(connectionStringName)
        {

        }

        /// <summary>
        /// Must be implemented to register a factory for resolving instances of <see cref="TUnitOfWork"/>.
        /// </summary>
        protected override void RegisterFactory(ContainerBuilder builder)
        {
            //builder.Register(c => new ClassifiedDenormalizer(c.Resolve<IClassifiedService>()));
            builder
                .RegisterType<ClassifiedService>()
                .As<IClassifiedService>()
                .SingleInstance();
            builder
                .RegisterType<RavenUnitOfWorkFactory>();
            builder
                .Register(c => c.Resolve<RavenUnitOfWorkFactory>().Create())  //gets concrete TUnitOfWork
                .ExternallyOwned();
        }
    }
}
