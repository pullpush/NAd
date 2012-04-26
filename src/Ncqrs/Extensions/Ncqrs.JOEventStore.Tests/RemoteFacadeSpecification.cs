using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventStore;
using EventStore.Dispatcher;
using EventStore.Persistence;
using Ncqrs.Domain;
using Ncqrs.Domain.Storage;
using Ncqrs.Eventing.Sourcing;
using NUnit.Framework;

namespace Ncqrs.JOEventStore.Tests
{
    [TestFixture]
    public class RemoteFacadeSpecification
    {
        private RemoteFacade _facade;
        private DomainRepository _repository;
        private OptimisticEventStore _eventStore;
        private InMemoryPersistenceEngine _persistenceEngine;
        private NullDispatcher _dispatcher;

        [Test]
        public void Storing_aggregate_should_preserve_values()
        {
            Guid aggregateId = Guid.NewGuid();
            Guid commandId = Guid.NewGuid();
            var commandMetadata = new CommandMetadata
                                      {
                                          CommandId = commandId,
                                          TargetType = typeof(TestAggregate),
                                          TargetId = aggregateId
                                      };
            _facade.Execute(commandMetadata, x => ((TestAggregate) x).TestMethod("Simon"));

            var restoredRoot = new TestAggregate(aggregateId);
             _repository.Load(restoredRoot, aggregateId, null);

            Assert.AreEqual("Simon", restoredRoot.HelloText);
        }

        [Test]
        public void Processing_the_same_command_twice_should_trow()
        {
            Guid aggregateId = Guid.NewGuid();

            var creatingCommandMetadata = new CommandMetadata
                                              {
                                                  CommandId = Guid.NewGuid(),
                                                  TargetType = typeof (TestAggregate),
                                                  TargetId = aggregateId
                                              };

            _facade.Execute(creatingCommandMetadata, x => ((TestAggregate)x).TestMethod("Creating..."));

            var duplicateCommandMetadata = new CommandMetadata
                                               {
                                                   CommandId = Guid.NewGuid(),
                                                   TargetType = typeof (TestAggregate),
                                                   TargetId = aggregateId
                                               };

            _facade.Execute(duplicateCommandMetadata, x => ((TestAggregate)x).TestMethod("First attempt"));

            Assert.Throws<DuplicateCommitException>(() => _facade.Execute(duplicateCommandMetadata, x => ((TestAggregate) x).TestMethod(
                "Second attempt")));
        }

        [Test]
        public void Processing_command_against_older_version_of_aggregate_should_throw()
        {
            Guid aggregateId = Guid.NewGuid();

            var creatingCommandMetadata = new CommandMetadata
                                              {
                                                  CommandId = Guid.NewGuid(),
                                                  TargetType = typeof (TestAggregate),
                                                  TargetId = aggregateId
                                              };

            _facade.Execute(creatingCommandMetadata, x => ((TestAggregate) x).TestMethod("Creating..."));

            var susequentCommandMetadata = new CommandMetadata
                                               {
                                                   CommandId = Guid.NewGuid(),
                                                   TargetType = typeof (TestAggregate),
                                                   TargetId = aggregateId
                                               };

            var yetAnotherCommandMetadata = new CommandMetadata
                                                {
                                                    CommandId = Guid.NewGuid(),
                                                    TargetType = typeof (TestAggregate),
                                                    TargetId = aggregateId,
                                                    LastKnownRevision = 1
                                                };

            _facade.Execute(susequentCommandMetadata, x => ((TestAggregate)x).TestMethod("First attempt"));

            Assert.Throws<ConcurrencyException>(() => _facade.Execute(yetAnotherCommandMetadata, x => ((TestAggregate)x).TestMethod(
                "Second attempt")));
        }


        public class TestAggregate : AggregateRootMappedByConvention
        {
            private string _helloText;

            public TestAggregate(Guid id) : base(id)
            {                
            }

            public string HelloText
            {
                get { return _helloText; }
            }

            public void TestMethod(string helloText)
            {
                ApplyEvent(new TestEvent(){HelloText = helloText});
            }

            private void OnTestEvent(TestEvent evnt)
            {
                _helloText = evnt.HelloText;
            }
        }

        public class TestEvent : SourcedEvent
        {
            public string HelloText { get; set; }
        }

        [SetUp]
        private void CreateFacade()
        {
            _persistenceEngine = new InMemoryPersistenceEngine();
            _dispatcher = new NullDispatcher();
            _eventStore = new OptimisticEventStore(_persistenceEngine, _dispatcher);
            _repository = new DomainRepository(_eventStore);
            _facade = new RemoteFacade(_repository,new SimpleAggregateRootCreationStrategy());
        }

        private class NullDispatcher : IDispatchCommits
        {
            private readonly List<Commit> _commits = new List<Commit>();

            public List<Commit> Commits
            {
                get { return _commits; }
            }

            public void Dispose()
            {
            }

            public void Dispatch(Commit commit)
            {
                _commits.Add(commit);
            }
        }
    }
}
