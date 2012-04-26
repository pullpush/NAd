// Type: Ncqrs.Domain.AggregateRoot
// Assembly: Ncqrs, Version=0.8.0.0, Culture=neutral
// Assembly location: D:\Projects\Workshop\NAd\Libs\debug\Ncqrs\Ncqrs.dll

using Ncqrs.Eventing;
using Ncqrs.Eventing.Sourcing;
using Ncqrs.Eventing.Sourcing.Mapping;
using System;

namespace Ncqrs.Domain
{
    public abstract class AggregateRoot : EventSource
    {
        protected AggregateRoot();
        protected AggregateRoot(Guid id);
        public static void RegisterThreadStaticEventAppliedCallback(Action<AggregateRoot, UncommittedEvent> callback);
        public static void UnregisterThreadStaticEventAppliedCallback(Action<AggregateRoot, UncommittedEvent> callback);

        [NoEventHandler]
        protected override void OnEventApplied(UncommittedEvent appliedEvent);
    }
}
