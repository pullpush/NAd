using System;
using Ncqrs.Domain;
using Ncqrs.Domain.Storage;

namespace Ncqrs.JOEventStore
{
    public interface IDomainRepository
    {
        void Load(AggregateRoot root, Guid id, int? lastKnownRevision);
        void Store(AggregateRoot root, Guid commandId);
    }
}