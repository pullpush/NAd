using System;
using System.Runtime.Serialization;

//using FluentValidation.Attributes;

using Ncqrs.Commanding;
//using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

//using NAd.Commanding.Validators;

namespace NAd.Commanding.Commands
{

    //[MapsToAggregateRootConstructor("NAd.Domain.Classified, NAd.Domain")]
    /// <summary>
    /// </summary>
    /// <remarks>
    /// The user interface sends commands to make changes to the system. 
    /// Commands are simple object that contain all the data needed to perform the underlying action.
    /// All commands are send to a Command Service. 
    /// This service receives the commands and routes them to the corresponding command executors. 
    /// All command executors respond to a specific command and execute an action based on there content.
    /// </remarks>
    //[Validator(typeof(CreateNewClassifiedValidator))]
    [Serializable]
    [DataContract]
    public class CreateNewClassifiedCommand : CommandBase
    {
        //[DataMember]
        //public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }


        //public CreateNewClassifiedCommand()
        //{
        //}

        //public CreateNewClassifiedCommand(Guid id, string name, string description)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //}
    }
}