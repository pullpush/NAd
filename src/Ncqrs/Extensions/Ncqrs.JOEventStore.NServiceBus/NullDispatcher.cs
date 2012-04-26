using EventStore.Dispatcher;
using EventStore.Persistence;

namespace Ncqrs.JOEventStore.NServiceBus
{
    public class NullDispatcher : IDispatchCommits
    {
        public void Dispose()
        {
        }

        public void Dispatch(Commit commit)
        {
        }
    }
}