
using System.Collections.Generic;
using System.Runtime.Serialization;

using NAd.Common;

namespace NAd.Commanding.ExceptionHandling
{
    [DataContract]
    public class ViolationDto
    {
        public ViolationDto(Violation violation)
        {
            RuleCode = violation.Rule.Code;
            Parameters = violation.Parameters;
        }

        [DataMember]
        public IDictionary<string,object> Parameters { get; private set; }

        [DataMember]
        public string RuleCode { get; private set; }
    }
}