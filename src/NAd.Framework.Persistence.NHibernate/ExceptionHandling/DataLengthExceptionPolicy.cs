
using System;
using NAd.Common;
using NAd.Common.ExceptionHandling;
using NHibernate.Exceptions;

namespace NAd.Framework.Persistence.NHibernate.ExceptionHandling
{
    /// <summary>
    /// Automatically processes exceptions caused by an attempt to insert or update that doesn't fit.
    /// </summary>
    internal class DataLengthExceptionPolicy : INHibernateExceptionPolicy
    {
        public Exception Process(Exception exception)
        {
            var adoException = exception as GenericADOException;
            if ((adoException != null) && DataWasTruncated(adoException))
            {
                exception = new ApplicationErrorException(ServiceError.DataSizeWasExceeded)
                {
                    {"EntityType", adoException.GetEntityType()}
                };
            }

            return exception;
        }

        private static bool DataWasTruncated(GenericADOException adoException)
        {
            Exception innerException = adoException.InnerException;

            return (innerException != null) && innerException.Message.ToLower().Contains("truncated");
        }
    }
}