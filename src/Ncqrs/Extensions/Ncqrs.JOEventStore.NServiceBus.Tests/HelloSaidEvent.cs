using Ncqrs.Eventing.Sourcing;

namespace Ncqrs.JOEventStore.NServiceBus.Tests
{
    public class HelloSaidEvent : SourcedEvent
    {
        public string HelloText { get; set; }
    }
}