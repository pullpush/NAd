using Autofac;
using NAd.Framework.Domain.Raven;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace NAd.Framework.Persistence.Raven
{
    public abstract class RavenUnitOfWorkModule<TUnitOfWork> : UnitOfWorkModule where TUnitOfWork : UnitOfWork
    {
        private readonly string _connectionStringName;

        protected RavenUnitOfWorkModule(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
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
            var documentStore = new DocumentStore { Url = _connectionStringName };
            documentStore.Initialize();

            //You can use this if you want Id to be a property that you control on your own 
            //and have raven use another property as the Classified id instead:

            //public class Classified
            //{
            //    public string ClassifiedId { get; set; }
            //    public Guid Id { get; set; }
            //    public string Name { get; set; }

            //    public ClassifiedId()
            //    {
            //        Id = Guid.NewGuid();
            //    }
            //}
            //documentStore.Conventions.FindIdentityProperty = prop =>
            //{
            //    if (prop.DeclaringType == typeof(Classified))
            //        return prop.Name == "ClassifiedId";

            //    return prop.Name == "Id";
            //};

            IndexCreation.CreateIndexes(typeof(Classified_ByAttribute).Assembly, documentStore);

            builder
                .RegisterInstance(documentStore)
                .SingleInstance()
                .As<IDocumentStore>();

            builder
                .Register(c => c.Resolve<IDocumentStore>().OpenSession())
                .InstancePerLifetimeScope()
                .Keyed<IDocumentSession>(typeof (TUnitOfWork));

            RegisterFactory(builder);
        }

        /// <summary>
        /// Must be implemented to register a factory for resolving instances of <see cref="TUnitOfWork"/>.
        /// </summary>
        protected abstract void RegisterFactory(ContainerBuilder builder);
    }
}
