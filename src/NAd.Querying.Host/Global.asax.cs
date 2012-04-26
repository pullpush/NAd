using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;

using Autofac;
using Autofac.Core;

using Microsoft.ApplicationServer.Http;
using System.ServiceModel.Activation;
using NAd.Framework.Hive.NHibernate;
using NAd.Framework.Hive.Raven;
using NAd.Framework.Services;
using NAd.Querying.Host.Infrastructure.ExceptionHandling;
using NAd.Querying.Host.Infrastructure.Formatters;
using NAd.Querying.Host.Resources.Classifieds;

//using NAd.Querying.Core.Services;
//using NAd.Querying.Core.Persistency;

using NAd.Querying.Host.Infrastructure.Linking;

namespace NAd.Querying.Host
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class Global : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<ClassifiedsResourceHandler>().AsSelf();
            containerBuilder.RegisterType<ClassifiedResourceHandler>().AsSelf();

            containerBuilder
                .RegisterType<ResourceLinker>()
                .As<IResourceLinker>()
                .WithParameter(new NamedParameter("baseUri", ConfigurationManager.AppSettings["BaseUri"]));


            containerBuilder.RegisterType<ClassifiedService>().As<IClassifiedService>();

            string connectionStringName = "QueryContext";
            containerBuilder.RegisterModule(new RavenUnitOfWorkModule(connectionStringName));

            IContainer container = containerBuilder.Build();

            //See: http://wcf.codeplex.com/discussions/272903

            //RouteTable.Routes.SetDefaultHttpConfiguration(
            var webApiConfig =
                new WebApiConfiguration()
                {
                    EnableTestClient = true,
                    CreateInstance = (serviceType, context, request) => container.Resolve(serviceType),
                    ErrorHandlers = (handlers, endpoint, descriptions) => handlers.Add(new WcfRestHttpErrorHandler()),
                    //Formatters = NewtonsoftJsonFormatter
                    //ResponseHandlers = 
                };

            //JsonMediaTypeFormatter jsonFormatter = webApiConfig.Formatters.JsonFormatter;
            //webApiConfig.Formatters.Remove(jsonFormatter);
            //webApiConfig.Formatters.Insert(0, jsonFormatter);

            var formatters = webApiConfig.Formatters;
            formatters.Clear();
            webApiConfig.Formatters.Insert(0, new NewtonsoftJsonFormatter());

            //See contribs:
            //http://webapicontrib.codeplex.com/SourceControl/list/changesets


            //custom formatters (beware of old code to plug them in)
            //http://geekswithblogs.net/michelotti/archive/2011/06/06/understanding-custom-wcf-web-api-media-type-processors-on-both.aspx

            //webApiConfig.Formatters.  //http://wcf.codeplex.com/discussions/274789
            //webApiConfig.MessageHandlerFactory = () => container.GetExportedValues<DelegatingHandler>();

            //http://blog.alexonasp.net/post/2011/07/26/Look-Ma-I-can-handle-JSONP-%28aka-Cross-Domain-JSON%29-with-WCF-Web-API-and-jQuery!.aspx
            //webApiConfig.AddResponseHandlers(c => c.Add(new JsonpResponseHandler()), (s, o) => true);

            RouteTable.Routes.MapServiceRoute<ClassifiedsResourceHandler>("classifieds", webApiConfig);

            RouteTable.Routes.MapServiceRoute<ClassifiedResourceHandler>("classified", webApiConfig);


            //RouteTable.Routes.Add(new ServiceRoute("ClassifiedsService", new NAdServiceHostFactory(), typeof(ClassifiedsService)));

            //routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            //);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //IocBootstrapper.BootUp();
        }
    }
}