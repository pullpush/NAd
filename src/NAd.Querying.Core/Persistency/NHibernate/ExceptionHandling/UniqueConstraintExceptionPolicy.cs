
using System;

using NAd.Common;
using NAd.Querying.Core.ExceptionHandling;

using NHibernate.Exceptions;

namespace NAd.Querying.Core.Persistency.NHibernate.ExceptionHandling
{
    /// <summary>
    /// Automatically processes unique constraint violations that occured in an NHibernate session
    /// </summary>
    internal class UniqueConstraintExceptionPolicy : INHibernateExceptionPolicy
    {
        public Exception Process(Exception exception)
        {
            var adoException = exception as GenericADOException;
            if ((adoException != null) && IsUniqueConstraintViolation(adoException))
            {
                exception = new ApplicationErrorException(ServiceError.NameCodeOrNumberIsNotUnique)
                {
                    {"EntityType", adoException.GetEntityType()}
                };
            }

            return exception;
        }

        private static bool IsUniqueConstraintViolation(GenericADOException adoException)
        {
            Exception innerException = adoException.InnerException;

            return (innerException != null) && 
                innerException.Message.ToLower().Contains("constraint") && 
                innerException.Message.ToLower().Contains("unique");
        }
    }
}