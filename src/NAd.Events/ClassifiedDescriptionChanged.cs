using System;

using Ncqrs.Eventing.Sourcing;

namespace NAd.Ncqrs.Events
{
    [Serializable]
    public class ClassifiedDescriptionChanged : SourcedEvent
    {
        //public Guid Id { get; set; }

        public Guid ClassifiedId
        {
            get { return EventSourceId; }
        }

        public string NewName { get; set; }

        public string NewDescription { get; set; }

        public DateTime DateUpdated
        {
            get;
            set;
        }
    }
}
