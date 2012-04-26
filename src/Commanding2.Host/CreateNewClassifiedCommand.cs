
using System;
using System.Runtime.Serialization;

using Ncqrs.Commanding;

namespace Commanding2.Host
{
    [Serializable]
    [DataContract]
    public class CreateNewClassifiedCommand : CommandBase
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}