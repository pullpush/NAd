using System;

using Ncqrs.Eventing.Sourcing;

namespace NAd.Events
{
    [Serializable]
    public class NewClassifiedCreated
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
