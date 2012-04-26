using System;
using System.Linq;
using EventStore;
using Ncqrs.Domain;
using Ncqrs.Eventing.Sourcing;

namespace Ncqrs.JOEventStore
{
    public class DomainRepository : IDomainRepository
    {
        private readonly IStoreEvents _eventStore;

        public DomainRepository(IStoreEvents eventStore)
        {
            _eventStore = eventStore;
        }

        public void Load(AggregateRoot root, Guid id, int? lastKnownRevision)
        {
            var stream = _eventStore.ReadUntil(id, lastKnownRevision ?? int.MaxValue);
            root.InitializeFromHistory(stream.Events.Cast<SourcedEvent>());
        }

        public void Store(AggregateRoot root, Guid commandId)
        {
            var commitAttempt = new CommitAttempt
                                    {
                                        CommitId = commandId,
                                        PreviousCommitSequence = (int)root.InitialVersion,
                                        StreamRevision = (int)root.Version,
                                        StreamId = root.EventSourceId
                                    };
            commitAttempt.Events.AddRange(root.GetUncommittedEvents().Select(x => new EventMessage
                                                                                      {
                                                                                          Body = x
                                                                                      }));
            _eventStore.Write(commitAttempt);
        }
    }
}