using Autofac;
using Autofac.Builder;
using NAd.Framework.Persistence.NHibernate;
using NAd.Framework.Persistence.NHibernate.ExceptionHandling;
using NAd.Framework.Services;


namespace NAd.Framework.Hive
{
    //public class NAdUnitOfWorkModule : NHibernateUnitOfWorkModule<NAdUnitOfWork>
    //{
    //    public NAdUnitOfWorkModule(string connectionStringName) : base(connectionStringName)
    //    {

    //    }

    //    /// <summary>
    //    /// Can be overriden to register any additional exception policies that need to be registered before
    //    /// the <see cref="NHibernateExceptionInterceptor"/> is registered.
    //    /// </summary>
    //    protected override void RegisterExceptionPolicies(ContainerBuilder builder)
    //    {
    //        builder.RegisterType<NAdExceptionPolicy>().As<INHibernateExceptionPolicy>();
    //    }

    //    /// <summary>
    //    /// Must be implemented to register a factory for resolving instances of <see cref="TUnitOfWork"/>.
    //    /// </summary>
    //    protected override void RegisterFactory(ContainerBuilder builder)
    //    {
    //        //builder.Register(c => new ClassifiedDenormalizer(c.Resolve<IClassifiedService>()));
    //        builder
    //            .RegisterType<ClassifiedService>()
    //            .As<IClassifiedService>()
    //            .SingleInstance();
    //        builder
    //            .RegisterType<NHibernateUnitOfWorkFactory>();
    //        builder
    //            .Register(c => c.Resolve<NHibernateUnitOfWorkFactory>().Create())  //gets concrete TUnitOfWork
    //            .ExternallyOwned();
    //    }
    //}
}