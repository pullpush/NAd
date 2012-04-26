using System;
using EventStore;
using EventStore.Dispatcher;
using EventStore.Persistence;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Domain;
using Ncqrs.Domain.Storage;
using Ncqrs.Eventing;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Storage;
using NServiceBus;
using NServiceBus.ObjectBuilder;

namespace Ncqrs.JOEventStore.NServiceBus
{
    public class ConfigNcqrs : Configure
    {        
        public void Configure(Configure config)
        {
            Builder = config.Builder;
            Configurer = config.Configurer;

            NcqrsEnvironment.RemoveDefault<IEventStore>();
            NcqrsEnvironment.RemoveDefault<IEventBus>();
            NcqrsEnvironment.RemoveDefault<IUnitOfWorkFactory>();

            config.Configurer.ConfigureComponent<RemoteFacade>(ComponentCallModelEnum.Singlecall);
            config.Configurer.ConfigureComponent<DomainRepository>(ComponentCallModelEnum.Singlecall);
            config.Configurer.ConfigureComponent<OptimisticEventStore>(ComponentCallModelEnum.Singlecall);

            Configurer.RegisterSingleton(typeof(IDispatchCommits), new NullDispatcher());

            if (!Configurer.HasComponent(typeof(IAggregateRootCreationStrategy)))
            {
                Configurer.RegisterSingleton(typeof(IAggregateRootCreationStrategy), new SimpleAggregateRootCreationStrategy());
            }
        }

        public ConfigNcqrs UseInMemoryPersistenceEngine()
        {
            Configurer.ConfigureComponent<InMemoryPersistenceEngine>(ComponentCallModelEnum.Singleton);
            return this;
        }

        public ConfigNcqrs UseDispatcher(IDispatchCommits commitDispatcher)
        {
            Configurer.RegisterSingleton(typeof(IDispatchCommits), commitDispatcher);
            return this;
        }
    }
}