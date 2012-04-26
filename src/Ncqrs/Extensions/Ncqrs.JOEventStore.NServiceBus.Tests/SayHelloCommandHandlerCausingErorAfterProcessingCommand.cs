using System;
using System.Threading;

namespace Ncqrs.JOEventStore.NServiceBus.Tests
{
    public class SayHelloCommandHandlerCausingErorAfterProcessingCommand : CommandHandlerBase<SayHelloCommandForTestingIdempotency, TestAggregate>      
    {
        public static bool SubsequentAttempt;
        public static bool Succeeded;
        public static ManualResetEvent SucceededEvent = new ManualResetEvent(false);

        public override void Handle(SayHelloCommandForTestingIdempotency message)
        {
            base.Handle(message);
            if (!SubsequentAttempt)
            {
                SubsequentAttempt = true;
                throw new Exception("Random exception after handling command.");
            }
            Succeeded = true;
            SucceededEvent.Set();
        }

        protected override CommandMetadata ExtractMetadata(SayHelloCommandForTestingIdempotency message)
        {
            return new CommandMetadata
                       {
                           CommandId = message.CommandId,
                           TargetId = message.TargetId,
                       };
        }

        protected override void Handle(SayHelloCommandForTestingIdempotency message, TestAggregate aggregateRoot)
        {
            aggregateRoot.SayHello(message.HelloText);
        }
    }
}