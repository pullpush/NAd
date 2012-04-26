using System;
using Ncqrs.Domain;

namespace Ncqrs.JOEventStore
{
    public interface IRemoteFacade
    {
        void Execute(CommandMetadata metadata, Action<AggregateRoot> commandAction);
    }
}