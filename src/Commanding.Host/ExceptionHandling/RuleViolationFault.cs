
using System.Runtime.Serialization;
using System.Linq;

using NAd.Common;
using NAd.Querying.Core.ExceptionHandling;

namespace NAd.Commanding.ExceptionHandling
{
    [DataContract]
    public class RuleViolationFault
    {
        public RuleViolationFault(RuleViolationException exception)
        {
            Violations = exception.Violations.Select(v => new ViolationDto(v)).ToArray();
        }

        [DataMember]
        public ViolationDto[] Violations { get; set; }
    }
}