using System.Runtime.Serialization;

using Ncqrs.Commanding;

namespace NAd.Commanding.Commands
{
    [DataContract]
    public abstract class ServicedCommand : CommandBase
    {
        /// <summary>
        /// Validates this instance against context-free constraints.
        /// </summary>
        //public abstract void Validate();
    }
}