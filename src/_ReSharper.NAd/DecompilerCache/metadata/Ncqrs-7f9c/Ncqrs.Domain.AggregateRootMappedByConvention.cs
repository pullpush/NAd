// Type: Ncqrs.Domain.AggregateRootMappedByConvention
// Assembly: Ncqrs, Version=0.8.0.0, Culture=neutral
// Assembly location: D:\Projects\Workshop\NAd\Libs\debug\Ncqrs\Ncqrs.dll

using Ncqrs.Eventing.Sourcing.Mapping;
using System;

namespace Ncqrs.Domain
{
    public abstract class AggregateRootMappedByConvention : MappedAggregateRoot
    {
        protected AggregateRootMappedByConvention();
        protected AggregateRootMappedByConvention(Guid id);
    }
}
