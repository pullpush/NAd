// Type: Ncqrs.Eventing.Sourcing.Mapping.MappedAggregateRoot
// Assembly: Ncqrs, Version=0.8.0.0, Culture=neutral
// Assembly location: D:\Projects\Workshop\NAd\Libs\debug\Ncqrs\Ncqrs.dll

using Ncqrs.Domain;
using System;

namespace Ncqrs.Eventing.Sourcing.Mapping
{
    public abstract class MappedAggregateRoot : AggregateRoot
    {
        protected MappedAggregateRoot(IEventHandlerMappingStrategy strategy);
        protected MappedAggregateRoot(Guid id, IEventHandlerMappingStrategy strategy);
        protected void InitializeHandlers();
    }
}
