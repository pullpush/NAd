using System;
using Ncqrs.Domain;
using Ncqrs.Domain.Storage;

namespace Ncqrs.JOEventStore
{
    public class RemoteFacade : IRemoteFacade
    {
        private readonly IDomainRepository _repository;
        private readonly IAggregateRootCreationStrategy _factory;

        public RemoteFacade(IDomainRepository repository, IAggregateRootCreationStrategy factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public void Execute(CommandMetadata metadata, Action<AggregateRoot> commandAction)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata", "Command metadata cannot be null.");
            }
            if (commandAction == null)
            {
                throw new ArgumentNullException("commandAction", "Command action cannot be null.");
            }
            if (metadata.CommandId == Guid.Empty)
            {
                throw new ArgumentException("Command id cannot be an empty GUID.", "metadata");
            }
            if (metadata.TargetId == Guid.Empty)
            {
                throw new ArgumentException("Target id cannot be an empty GUID.", "metadata");
            }
            if (metadata.TargetType == null)
            {
                throw new AggregateException("Target type cannot be null.");
            }

            var target = _factory.CreateAggregateRoot(metadata.TargetType, metadata.TargetId);
            _repository.Load(target, metadata.TargetId, metadata.LastKnownRevision);
            commandAction(target);
            _repository.Store(target, metadata.CommandId);
        }
    }
}