using System;

using Ncqrs.Eventing.Sourcing;
using Ncqrs.Domain;

namespace NAd.Ncqrs.Events
{
    /// <summary>
    /// Relates to the state change of the <see cref="Classified"/> domain object.
    /// </summary>
    /// <remarks>
    /// All state changes in the domain are represented by domain events. 
    /// They are simple object that contain all data related to the change. 
    /// Notice that the names are in the past tense.
    /// 
    /// The repository is used to get and save aggregate roots. 
    /// This is done by there events. 
    /// Saving an aggregate root will result in persisting all his uncommitted events 
    /// that occurred while making change to it. 
    /// Getting an aggregate root is done by getting this events and replaying them 
    /// to build up the aggregate root into the latest state.
    /// 
    /// The events are stored in the event store and when an aggregate root is saved, 
    /// all the events will also be published to the event store.
    /// 
    /// </remarks>
    [Serializable]
    public class NewClassifiedCreated : SourcedEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //public long Version { get; set; }

        public DateTime CreationDate
        {
            get;
            set;
        }
    }
}
