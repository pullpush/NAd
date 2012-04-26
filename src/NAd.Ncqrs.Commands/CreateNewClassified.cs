using System;

using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace NAd.Ncqrs.Commands
{
    [MapsToAggregateRootConstructor("NAd.Ncqrs.Domain.Classified, NAd.Ncqrs.Domain")]
    public class CreateNewClassified : CommandBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CreateNewClassified()
        {
        }

        public CreateNewClassified(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
