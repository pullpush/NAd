using System;
using EventStore;
using Ncqrs.Domain;
using NServiceBus;

namespace Ncqrs.JOEventStore.NServiceBus
{
    public abstract class CommandHandlerBase<TMessage, TAggregateRoot> : IHandleMessages<TMessage>
        where TMessage : IMessage
        where TAggregateRoot : AggregateRoot
    {
        public IRemoteFacade RemoteFacade { get; set; }
        public IBus Bus { get; set; }

        public virtual void Handle(TMessage message)
        {
            var metadata = ExtractMetadata(message);
            if (metadata.TargetType == null)
            {
                metadata.TargetType = typeof (TAggregateRoot);
            }
            try
            {
                RemoteFacade.Execute(metadata, x => Handle(message, (TAggregateRoot)x));
            }
            catch (DuplicateCommitException ex)
            {                
                _logger.InfoFormat("Detected duplicate command NSB ID={0},Logical ID={1}. Skipping.",Bus.CurrentMessageContext.Id, metadata.CommandId);
            }
        }

        protected abstract CommandMetadata ExtractMetadata(TMessage message);
        protected abstract void Handle(TMessage message, TAggregateRoot aggregateRoot);

        private static readonly ILog _logger = LogManager.GetLogger(typeof (CommandHandlerBase<,>));
    }
}