using System.Threading;
using NServiceBus;

namespace Ncqrs.JOEventStore.NServiceBus.Tests
{
    public class SayHelloCommandHandler : CommandHandlerBase<SayHelloCommand, TestAggregate>
    {
        public static bool Succeeded;
        public static ManualResetEvent SucceededEvent = new ManualResetEvent(false);

        protected override CommandMetadata ExtractMetadata(SayHelloCommand message)
        {
            return new CommandMetadata
                       {
                           CommandId = message.CommandId,
                           TargetId = message.TargetId,
                       };
        }

        protected override void Handle(SayHelloCommand message, TestAggregate aggregateRoot)
        {
            aggregateRoot.SayHello(message.HelloText);
            Succeeded = true;
            SucceededEvent.Set();
        }
    }
}