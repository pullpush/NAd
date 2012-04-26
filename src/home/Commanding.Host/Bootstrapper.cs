using System.Reflection;

using NAd.Commanding.Host.Commands;

using Autofac;
using Autofac.Configuration;
using log4net;
using log4net.Appender;
using NServiceBus;

using Ncqrs;
using Ncqrs.Config.Autofac;
using Ncqrs.EventBus;
using Ncqrs.NServiceBus;

using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Storage.JOliver;
using Ncqrs.Eventing.Storage.RavenDB;

using Ncqrs.Commanding;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.CommandService.Infrastructure;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

//using Ncqrs.Bus;
//using Ncqrs.Bus.NServiceBus;
//using Ncqrs.CommandExecution.AutoMapping;
//using Ncqrs.CommandHandling;
//using Ncqrs.CommandHandling.Dispatching;
//using Ncqrs.Domain;
//using Ncqrs.Domain.Bus;
//using Ncqrs.EventSourcing.EntityFramework;
//using Ncqrs.EventSourcing.Storage;

//using NAd.UI.Infrastructure;

namespace NAd.Commanding.Host
{
    public class Bootstrapper
    {
        public static void Bootstrap()
        {
            SetupDependencies();
        }


        private static void SetupDependencies()
        {
            IContainer container = null;
            var containerBuilder = new ContainerBuilder();
            
            //containerBuilder.RegisterModule<ApplicationServicesModule>();
            //containerBuilder.RegisterType<NsbEventBus>().As<IEventBus>();
            containerBuilder.RegisterType<RavenDBEventStore>().As<IEventStore>();
            containerBuilder.RegisterInstance<ICommandService>(InitializeCommandService());
            containerBuilder.RegisterInstance<IEventBus>(InitializeEventBus());

            //InitializeNServiceBus(container);

            containerBuilder.Register(x => container);
            
            // var config = new AutofacConfiguration(x =>
            // {
            // var eventBus = InitializeEventBus();
            // var eventStore = InitializeEventStore();
            // x.For{IEventBus}().Use(eventBus);
            // x.For{IEventStore}().Use(eventStore);
            // x.For{IUnitOfWorkFactory}().Use{UnitOfWorkFactory}();
            // }
            //);
            container = containerBuilder.Build();
            AutofacConfiguration config = new AutofacConfiguration(container);

            // I believe this is a single call to configure inject all component dependencies
            // e.g. NcqrsEnvironment.SetDefault<IEventBus>( InitializeEventBus() );
            NcqrsEnvironment.Configure(config);
        }


        private static IBus InitializeNServiceBus(IContainer container)
        {
            //Configure.With()
            //    .Log4Net<FileAppender>(a =>
            //    {
            //        a.AppendToFile = false;
            //        a.File = ".\\nservicebus.log";
            //    })  
            //    .DefaultBuilder()
            //    .BinarySerializer()
            //    .InstallNcqrs();


            //The additional UseInMemoryPersistenceEngine method instructs Event Store which storage engine to use.
            IBus bus = Configure.With()
                .Log4Net()
                .DefaultBuilder()
                .XmlSerializer()
                .MsmqTransport()
                .IsTransactional(false)
                .PurgeOnStartup(true)
                .UnicastBus()
                .LoadMessageHandlers()
                .InstallNcqrs()
                //.UseInMemoryPersistenceEngine()
                .CreateBus()
                .Start();            

            //InitializeNHibernateForBus(container);

            //IBus bus = Configure.WithWeb()
            //   .ContainerBuilder(container)
            //   .XmlSerializer()
            //   .MsmqTransport()
            //   .IsTransactional(true)
            //   .PurgeOnStartup(false)
            //   .UnicastBus()
            //   .ImpersonateSender(false)
            //   .LoadMessageHandlers()
            //   .DBSubcriptionStorage()
            //   .InMemoryFaultManager()
            //   .CreateBus()
            //   .Start();
            ////bus.Subscribe<CargoAssignedToRouteMessage>();
            //bus.Subscribe<CargoHandledMessage>();
            //bus.Subscribe<CargoDestinationChangedMessage>();
            //bus.Subscribe<CargoRegisteredMessage>();
        
            return bus;
        }

        private static ICommandService InitializeCommandService()
        {
            var commandAssembly = typeof(CreateNewClassifiedCommand).Assembly;

            var service = new CommandService();
            service.RegisterExecutorsInAssembly(commandAssembly);
            service.AddInterceptor(new ThrowOnExceptionInterceptor());

            //service.RegisterExecutor(new PostNewTweetCommandExecutor());
            return service;
        }

        private static IEventBus InitializeEventBus()
        {
            var bus = new InProcessEventBus();

            bus.RegisterAllHandlersInAssembly(typeof(Bootstrapper).Assembly);
            //bus.RegisterHandler(new InMemoryBufferedEventHandler(buffer));

            return bus;
        }

        //private static void InitializeNServiceBus()
        //{
        //    SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);

        //    IBus bus = Configure.WithWeb()
        //        .Log4Net<FileAppender>(a =>
        //        {
        //            a.AppendToFile = false;
        //            a.File = ".\\nservicebus.log";
        //        })
        //        .DefaultBuilder()
        //        .XmlSerializer()
        //        .MsmqTransport().IsTransactional(true)
        //        .MsmqSubscriptionStorage()
        //        .UnicastBus()
        //            .LoadMessageHandlers()
        //        .CreateBus()
        //        .Start();


        //    NcqrsEnvironment.SetDefault<IBus>(bus);

        //    //WindsorConfiguration config = new WindsorConfiguration(container);

        //    //NcqrsEnvironment.Configure(config);

        //    //ServiceLocator.Current.RegisterInstance(new NsbEventBus(bus));
        //    //ServiceLocator.Current.RegisterInstance(new DistributedEventBus(bus));
        //}
    }
}