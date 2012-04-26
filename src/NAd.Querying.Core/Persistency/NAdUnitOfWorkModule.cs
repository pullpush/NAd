using Autofac;

using Ncqrs.Domain;

using NAd.Querying.Core.Persistency.NHibernate;
using NAd.Querying.Core.Persistency.NHibernate.ExceptionHandling;
using NAd.Querying.Core.Services;
//using NAd.Querying.Core.Denormalizers;

namespace NAd.Querying.Core.Persistency
{
    public class NAdUnitOfWorkModule : NHibernateUnitOfWorkModule<NAdUnitOfWork>
    {
        public NAdUnitOfWorkModule(string connectionStringName) : base(connectionStringName)
        {

        }

        /// <summary>
        /// Can be overriden to register any additional exception policies that need to be registered before
        /// the <see cref="NHibernateExceptionInterceptor"/> is registered.
        /// </summary>
        protected override void RegisterExceptionPolicies(ContainerBuilder builder)
        {
            builder.RegisterType<NAdExceptionPolicy>().As<INHibernateExceptionPolicy>();
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
                .RegisterType<NAdUnitOfWorkFactory>();
            builder
                .Register(c => c.Resolve<NAdUnitOfWorkFactory>().Create())
                .ExternallyOwned();
        }
    }
}