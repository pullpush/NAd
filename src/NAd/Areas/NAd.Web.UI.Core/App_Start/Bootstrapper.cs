
using System;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

using Autofac;
using NAd.Framework.Persistence.Abstractions;
using NAd.Framework.Persistence.Abstractions.Model;
using NAd.Web.UI.Core.Common;
using NAd.Web.UI.Core.Facade;
using NAd.Web.UI.Core.Web.Mvc;
using NAd.Web.UI.Core.Web.Routing;
using Ncqrs.CommandService.Contracts;

namespace NAd.Web.UI.Core.App_Start 
{
    /// <summary>
    /// Bootstrapper for StructureMap
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Bootstrapper {

        /// <summary>
        /// Configures StructureMap to look for registries.
        /// </summary>
        /// <returns></returns>
        public static IContainer Initialize() {
            
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<VirtualPathResolver>().As<IVirtualPathResolver>();
            containerBuilder.RegisterType<PathData>().As<IPathData>();
            containerBuilder.RegisterType<PathResolver>().As<IPathResolver>();

            containerBuilder
                .RegisterInstance<ChannelFactory<ICommandWebServiceClient>>(new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient"))
                .SingleInstance();

            //containerBuilder.RegisterType<PageServiceFacade>().As<IPageServiceFacade>();
            containerBuilder
                .RegisterType<PageServiceFacade>()
                .As<IPageServiceFacade>()
                .WithParameter(new NamedParameter("baseAddress", ConfigurationManager.AppSettings["BaseUri"]));

            containerBuilder.RegisterType<ControllerMapper>().As<IControllerMapper>();
            containerBuilder.Register(
                c => ((MvcHandler) HttpContext.Current.Handler).RequestContext.RouteData.GetCurrentModel<IPageModel>())
                .As<IPageModel>();

            IContainer container = containerBuilder.Build();

            return container;

            /*
            ObjectFactory.Initialize(x => {

                var documentStore = new EmbeddableDocumentStore { ConnectionStringName = "RavenDB" };
                
                documentStore.RegisterListener(new StoreListener());
                documentStore.RegisterListener(new DeleteListener());

                documentStore.Initialize();
                documentStore.Conventions.FindTypeTagName = type => typeof(IPageModel).IsAssignableFrom(type) ? "pages" : null;
                
                IndexCreation.CreateIndexes(typeof(Documents_ByParent).Assembly, documentStore);

                x.For<IDocumentStore>().Use(documentStore);

                x.For<IDocumentSession>()
                    .HybridHttpOrThreadLocalScoped()
                    .Use(y =>
                    {
                        var store = y.GetInstance<IDocumentStore>();
                        return store.OpenSession();
                    });

                x.For<IVirtualPathResolver>().Use<VirtualPathResolver>();
                x.For<IPathResolver>().Use<PathResolver>();
                x.For<IPathData>().Use<PathData>();
                x.For<IPageRepository<,>>().Use<PageRepository>();
                x.For<IRepository<IPageModel>>().Use<PageRepository>();

                x.For<IControllerMapper>().Use<ControllerMapper>();

                x.For<ISettings>().Use<Settings>();
                x.For<IPageModel>().UseSpecial(y => y.ConstructedBy( r => ((MvcHandler) HttpContext.Current.Handler).RequestContext.RouteData.GetCurrentModel<IPageModel>()));
            });

            return ObjectFactory.Container;
            */

        }
    }
}