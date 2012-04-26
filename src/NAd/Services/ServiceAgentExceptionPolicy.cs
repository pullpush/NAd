
using System;
using System.ServiceModel;

using NAd.Common;

using NAd.UI.Commanding;

using System.Linq;

namespace NAd.UI.Services
{
    internal static class ServiceAgentExceptionPolicy
    {
        public static Exception Process(Exception exception)
        {
            //var applicationErrorException = exception as FaultException<ApplicationErrorFault>;
            //if (applicationErrorException != null)
            //{
            //    ApplicationErrorFault errorFault = applicationErrorException.Detail;
            //    return new ApplicationErrorException(new Error(errorFault.ErrorCode), errorFault.Parameters);
            //}

            //var ruleViolationException = exception as FaultException<RuleViolationFault>;
            //if (ruleViolationException != null)
            //{
            //    RuleViolationFault ruleViolationFault = ruleViolationException.Detail;
            //    return new RuleViolationException(ruleViolationFault.Violations.Select(
            //        v => new Violation(new Rule(v.RuleCode), v.Parameters)));
            //}

            return exception;
        }
    }
}