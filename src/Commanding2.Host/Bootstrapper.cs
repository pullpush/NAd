using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Storage;

using NAd.Events;

namespace Commanding2.Host
{
    public static class Bootstrapper
    {
        public static void BootUp()
        {
            NcqrsEnvironment.SetDefault<ICommandService>(InitializeCommandService());
            NcqrsEnvironment.SetDefault<IEventStore>(InitializeEventStore());
            NcqrsEnvironment.SetDefault<IEventBus>(InializeEventBus());
        }

        private static IEventBus InializeEventBus()
        {
            var bus = new Ncqrs.Eventing.ServiceModel.Bus.InProcessEventBus();
            bus.RegisterHandler<NewClassifiedCreated>(new ClassifiedDenormalizer());
            return bus;
        }

        private static ICommandService InitializeCommandService()
        {
            var service = new Ncqrs.Commanding.ServiceModel.CommandService();
            //service.RegisterExecutor(new CreateNewClassifiedCommandExecutor());
            return service;
        }

        private static IEventStore InitializeEventStore()
        {
            var connectionString = @"Data Source=(local)\sqlexpress;database=NCQRSDemoEventStore;integrated security=true;";
            return new Ncqrs.Eventing.Storage.SQL.MsSqlServerEventStore(connectionString);
        }
    }
}