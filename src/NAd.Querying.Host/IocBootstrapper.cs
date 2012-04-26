
using System;
using System.Configuration;
using System.Linq;
using System.Web.Routing;

using Microsoft.ApplicationServer.Http;
using Microsoft.ApplicationServer.Http.Description;

using Autofac;
using Autofac.Integration.Wcf;
using NAd.Framework.Services;

//using NAd.Querying.Core.Common;
//using NAd.Querying.Core.Persistency;
//using NAd.Querying.Core.Services;

namespace NAd.Querying.Host
{
    public class IocBootstrapper
    {
        public static void BootUp()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<EntLibLogger>().As<ILogger>();
            //builder
            //    .RegisterType<ClassifiedsService>();
            //    //.AsImplementedInterfaces();

            //builder
            //    .RegisterType<ClassifiedResources>();
            //    //.AsImplementedInterfaces();

            //string connectionStringName = "QueryContext";
            //builder.RegisterModule(new NAdUnitOfWorkModule(connectionStringName));

            //builder
            //    .RegisterAssemblyTypes(typeof(BatchedCommandExecutor).Assembly)
            //    .Where(IsCommandHandler)
            //    .AsImplementedInterfaces();

            //builder.RegisterType<AttributeMappedCommandHandler>();
            //builder.RegisterType<BatchedCommandExecutor>();


            //var configuration = HttpHostConfiguration.Create()
            //       .SetResourceFactory(new LightCoreResourceFactory(container));  

            IContainer container = builder.Build();


            RouteTable.Routes.SetDefaultHttpConfiguration(
                new WebApiConfiguration()
                {
                    EnableTestClient = true,
                    CreateInstance = (serviceType, context, request) => container.Resolve<IClassifiedService>(),
                }
            );


            //Ioc.Global = container;
            //AutofacHostFactory.Container = container;
        }

        //private static bool IsCommandHandler(Type type)
        //{
        //    return !type.IsAbstract &&
        //            type.GetInterfaces().Any(i => i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IHandles<>)));
        //}
    }
}