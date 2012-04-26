using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using EventStore.Persistence;
using NServiceBus;
using NServiceBus.ObjectBuilder;
using NServiceBus.Unicast.Config;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Ncqrs.JOEventStore.NServiceBus.Tests
{
    [TestFixture]
    public class NsbIntegrationTests
    {
        private const string QueueName = "Ncqrs_JOEventStore_NServiceBus_Tests";
        private IBus _bus;

        [Test]
        public void Command_should_be_processed()
        {
            _bus.Send(QueueName, new SayHelloCommand
                                     {
                                         HelloText = "Hello NCQRS",
                                         CommandId = Guid.NewGuid(),
                                         TargetId = Guid.NewGuid()
                                     });

            SayHelloCommandHandler.SucceededEvent.WaitOne(TimeSpan.FromSeconds(10));
            Assert.IsTrue(SayHelloCommandHandler.Succeeded);
        }

        [Test]
        public void Command_should_be_processed_only_once()
        {
            _bus.Send(QueueName, new SayHelloCommandForTestingIdempotency
                                     {
                                         HelloText = "Hello NCQRS",
                                         CommandId = Guid.NewGuid(),
                                         TargetId = Guid.NewGuid()
                                     });

            SayHelloCommandHandlerCausingErorAfterProcessingCommand.SucceededEvent.WaitOne(TimeSpan.FromSeconds(10));
            Assert.IsTrue(SayHelloCommandHandlerCausingErorAfterProcessingCommand.Succeeded);
        }

        [SetUp]
        public void Initialize()
        {
            _bus = Configure.With()
                .Log4Net()
                .DefaultBuilder()
                .XmlSerializer()
                .MsmqTransport()
                .IsTransactional(true)
                .PurgeOnStartup(true)
                .UnicastBus()
                .LoadMessageHandlers()
                .InstallNcqrs()
                .UseInMemoryPersistenceEngine()
                .CreateBus()
                .Start();
        }
    }
}
// ReSharper restore InconsistentNaming

