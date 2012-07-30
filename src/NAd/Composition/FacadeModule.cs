using System.ServiceModel;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using Autofac;
using NAd.Framework.Persistence.Abstractions.Model;
using NAd.UI.Facade;
using NAd.Querying.Host.Resources.Classifieds;
using NAd.Querying.Host.Infrastructure.Linking;
//using NAd.Querying.Core.Services;
using NAd.Framework.Services;
using NAd.Web.UI.Core.Common;
using NAd.Web.UI.Core.Facade;
using NAd.Web.UI.Core.Web.Routing;
using Ncqrs.CommandService;
using Ncqrs.CommandService.Contracts;

namespace NAd.UI.Composition
{
    public class FacadeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClassifiedServiceFacade>().AsSelf();

            //builder
            //    .RegisterType<PageServiceFacade>()
            //    .As<IPageServiceFacade>()
            //    .WithParameter(new NamedParameter("baseAddress", ConfigurationManager.AppSettings["BaseUri"]));

            //builder.RegisterType<PathData>().As<IPathData>();

            //builder.Register<IPageModel>(y => y.ConstructedBy(r => ((MvcHandler)HttpContext.Current.Handler).RequestContext.RouteData.GetCurrentModel<IPageModel>()));


            //builder
            //    .RegisterInstance<ChannelFactory<ICommandWebServiceClient>>(new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient"))
            //    .SingleInstance();

            //builder
            //    .RegisterType<ChannelFactory<ICommandWebServiceClient>>()
            //    .AsSelf()
            //    .WithParameter(new TypedParameter(typeof(string), "CommandWebServiceClient"))
            //    .SingleInstance();


            //builder.RegisterType<ClassifiedResourceHandler>().AsSelf();

            //builder
            //    .RegisterType<ResourceLinker>()
            //    .As<IResourceLinker>()
            //    .WithParameter(new NamedParameter("baseUri", ConfigurationManager.AppSettings["BaseUri"]));

            //builder.RegisterType<ClassifiedService>().As<IClassifiedService>();



            //builder.RegisterInstance<ChannelFactory<ICommandWebServiceClient>>(new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient"));


            //builder.RegisterType<ClassifiedResourceHandler>().AsSelf();

            //builder
            //    .RegisterType<ResourceLinker>()
            //    .As<IResourceLinker>()
            //    .WithParameter(new NamedParameter("baseUri", ConfigurationManager.AppSettings["BaseUri"]));


            //builder.Register<ClassifiedServiceFacade>(c => new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient"));

            //builder.Register<ChannelFactory<ICommandWebServiceClient>>((c) => {c.Resolve });

            //builder
            //    .RegisterType<ChannelFactory<ICommandWebServiceClient>>()
            //    .AsSelf()
            //    .WithParameter(new TypedParameter(typeof(string), "CommandWebServiceClient"))
            //    .SingleInstance();

            //builder.RegisterType<CommandWebService>().As<ICommandWebServiceClient>();




            //builder.RegisterType<HandlingEventServiceFacade>().AsSelf();
        }
    }
}