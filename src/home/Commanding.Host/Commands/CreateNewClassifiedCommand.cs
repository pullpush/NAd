using System;

using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace NAd.Commanding.Host.Commands
{
    [MapsToAggregateRootConstructor("NAd.Domain.Classified, NAd.Domain")]
    public class CreateNewClassifiedCommand : CommandBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public CreateNewClassifiedCommand()
        {
        }

        public CreateNewClassifiedCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}