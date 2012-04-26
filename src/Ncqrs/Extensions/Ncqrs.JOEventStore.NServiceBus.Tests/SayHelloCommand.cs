using System;
using NServiceBus;

namespace Ncqrs.JOEventStore.NServiceBus.Tests
{
    [Serializable]
    public class SayHelloCommand : IMessage
    {
        public Guid CommandId { get; set;}
        public Guid TargetId { get; set;}
        public string HelloText { get; set; }
    }
}