using System;

using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace NAd.Ncqrs.Commands
{
    [Serializable]
    [MapsToAggregateRootMethod("NAd.Ncqrs.Domain.Classified, NAd.Ncqrs.Domain", "ChangeClassifiedDescription")]
    public class ChangeClassifiedDescription : CommandBase
    {
        [AggregateRootId]
        public Guid ClassifiedId { get; set; }

        public string NewName { get; set; }

        public string NewDescription { get; set; }

        //public ChangeClassifiedDescription()
        //{
        //}

        public ChangeClassifiedDescription(Guid id, string name, string description)
        {
            ClassifiedId = id;
            NewName = name;
            NewDescription = description;
        }
    }
}
