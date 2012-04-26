
using System;
using System.Configuration;

using Autofac;
using Autofac.Integration.Wcf;

//using Cookbook.Services.Core.Commanding;
//using Cookbook.Services.Core.Common;
//using Cookbook.Services.Core.Handlers;
//using Cookbook.Services.Core.Persistency;

using NAd.Querying.Core.Common;

using System.Linq;

namespace NAd.Querying
{
    public class IocBootstrapper
    {
        public void Start()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<EntLibLogger>().As<ILogger>();
            builder.RegisterType<QueryService>();

            //string connectionStringName = "Cookbook";
            //builder.RegisterModule(new CookbookUnitOfWorkModule(connectionStringName));

            //builder
            //    .RegisterAssemblyTypes(typeof(BatchedCommandExecutor).Assembly)
            //    .Where(IsCommandHandler)
            //    .AsImplementedInterfaces();

            //builder.RegisterType<AttributeMappedCommandHandler>();
            //builder.RegisterType<BatchedCommandExecutor>();

            IContainer container = builder.Build();

            Ioc.Global = container;
            AutofacHostFactory.Container = container;
        }

        //private static bool IsCommandHandler(Type type)
        //{
        //    return !type.IsAbstract &&
        //            type.GetInterfaces().Any(i => i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IHandles<>)));
        //}
    }
}