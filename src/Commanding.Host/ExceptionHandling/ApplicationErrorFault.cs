
using System.Collections.Generic;
using System.Runtime.Serialization;

using NAd.Common;

namespace NAd.Commanding.ExceptionHandling
{
    [DataContract]
    public class ApplicationErrorFault
    {
        public ApplicationErrorFault(ApplicationErrorException exception)
        {
            ErrorCode = exception.Error.Code;
            Parameters = exception.Parameters;
        }

        [DataMember]
        public IDictionary<string, object> Parameters { get; private set; }

        [DataMember]
        public string ErrorCode { get; private set; }
    }
}