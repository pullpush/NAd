
using Autofac;

using NAd.Common;

using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Instances;

using HibernatingRhinos.Profiler.Appender.NHibernate;
using NAd.Framework.Domain;
using NAd.Framework.Domain.NHibernate.MappingOverrides;
using NAd.Framework.Persistence.Abstractions;
using NAd.Framework.Persistence.NHibernate.ExceptionHandling;
using NHibernate;
//using NHibernate.ByteCode.Castle;
using NHibernate.Cfg.Loquacious;

using AutofacContrib.DynamicProxy2;

namespace NAd.Framework.Persistence.NHibernate
{
    public abstract class NHibernateUnitOfWorkModule<TUnitOfWork> : UnitOfWorkModule where TUnitOfWork : UnitOfWork
    {
        private readonly string connectionStringName;

        public NHibernateUnitOfWorkModule(string connectionStringName)
        {
            this.connectionStringName = connectionStringName;
        }

        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        /// <param name="builder">The builder through which components can be
        ///             registered.</param>
        protected override void Load(ContainerBuilder builder)
        {
            RegisterExceptionPolicies(builder);

            var fluentConfiguration = CreateFluentConfiguration();

            //ConfigureProfiling(fluentConfiguration);

            builder.RegisterInstance(fluentConfiguration.BuildConfiguration()); 
            builder.RegisterInstance(fluentConfiguration.BuildSessionFactory()).As<ISessionFactory>();
            
            builder.RegisterType<NHibernateExceptionInterceptor>();
            builder.RegisterType<UniqueConstraintExceptionPolicy>().As<INHibernateExceptionPolicy>();
            builder.RegisterType<ForeignKeyConstraintExceptionPolicy>().As<INHibernateExceptionPolicy>();
            builder.RegisterType<DataLengthExceptionPolicy>().As<INHibernateExceptionPolicy>();

            builder
                .Register(c => c.Resolve<ISessionFactory>().OpenSession())
                .EnableInterfaceInterceptors()
                .Keyed<ISession>(typeof (TUnitOfWork))
                .InterceptedBy(typeof(NHibernateExceptionInterceptor));

            RegisterFactory(builder);
        }

        /// <summary>
        /// Can be overriden to register any additional exception policies that need to be registered before
        /// the <see cref="NHibernateExceptionInterceptor"/> is registered.
        /// </summary>
        protected virtual void RegisterExceptionPolicies(ContainerBuilder builder)
        {
            
        }

        /// <summary>
        /// Must be implemented to register a factory for resolving instances of <see cref="TUnitOfWork"/>.
        /// </summary>
        protected abstract void RegisterFactory(ContainerBuilder builder);

        protected FluentConfiguration CreateFluentConfiguration()
        {
            return Fluently.Configure()
                .Database(DatabaseConfiguration)
                //.ExposeConfiguration(config => config.LinqToHqlGeneratorsRegistry<EqualsLinqToHqlGeneratorsRegistry>())
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Classified>(new AutoMappingConfiguration())
                    .UseOverridesFromAssemblyOf<ClassifiedMappingOverride>()
                    .Conventions.Add(
                        ForeignKey.EndsWith(DatabaseConstants.IdentitySuffix),
                        Table.Is(x => x.EntityType.Name.Pluralize()),
                        OptimisticLock.Is(x => x.Version()),
                        new DiscriminatorConvention())));
        }

        /// <summary>
        /// Gets the configuration of the database associated with the <see cref="TUnitOfWork"/>.
        /// </summary>
        protected virtual IPersistenceConfigurer DatabaseConfiguration
        {
            get
            {
                return MsSqlConfiguration
                    .MsSql2008
                    .ConnectionString(c => c.FromConnectionStringWithKey(connectionStringName));
                    //.ProxyFactoryFactory(typeof(ProxyFactoryFactory).AssemblyQualifiedName);
            }
        }

        //private static void ConfigureProfiling(FluentConfiguration fluentConfiguration)
        //{
        //    if (EnableProfiling)
        //    {
        //        NHibernateProfiler.Initialize();
        //        fluentConfiguration.ExposeConfiguration(cfg => cfg.SetProperty("generate_statistics", "true"));
        //    }
        //}

        //private static bool EnableProfiling
        //{
        //    get
        //    {
        //        string value = ConfigurationManager.AppSettings["EnableProfiling"];
        //        return value.IsNotNullOrEmpty() && (value.ToLower() == "true");
        //    }
        //}

        private class DiscriminatorConvention : ISubclassConvention
        {
            public void Apply(ISubclassInstance instance)
            {
                instance.DiscriminatorValue(instance.EntityType.Name);
            }
        }
    }
}