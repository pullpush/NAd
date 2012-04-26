
using System;

using NAd.Common;
using NAd.Querying.Core.ExceptionHandling;

using NHibernate.Exceptions;

namespace NAd.Querying.Core.Persistency.NHibernate.ExceptionHandling
{
    /// <summary>
    /// Automatically processes foreign key constraint violations that occured in an NHibernate session
    /// </summary>
    internal class ForeignKeyConstraintExceptionPolicy : INHibernateExceptionPolicy
    {
        public Exception Process(Exception exception)
        {
            var adoException = exception as GenericADOException;
            if ((adoException != null) && AppliesToThisPolicy(adoException))
            {
                exception = new ApplicationErrorException(ServiceError.RecordIsUsedByAnotherRecord)
                {
                    {"EntityType", adoException.GetEntityType()}
                };
            }

            return exception;
        }

        private static bool AppliesToThisPolicy(GenericADOException adoException)
        {
            Exception innerException = adoException.InnerException;

            return (innerException != null) && 
                innerException.Message.ToLower().Contains("constraint") && 
                    innerException.Message.ToLower().Contains("reference");
        }
    }
}