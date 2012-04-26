
using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;

using NAd.Common;
using NAd.Querying.Core.Common;

namespace NAd.Commanding.ExceptionHandling
{
    public class LastChanceErrorHandler : IErrorHandler
    {
        //private readonly ILogger logger = new EntLibLogger();
        private static int internalErrorCount;

        /// <summary>
        ///   Enables the creation of a custom <see cref = "T:System.ServiceModel.FaultException`1" /> that is returned from an exception in the course of a service method.
        /// </summary>
        /// <param name = "exception">The <see cref = "T:System.Exception" /> object thrown in the course of the service operation.</param>
        /// <param name = "version">The SOAP version of the message.</param>
        /// <param name = "fault">The <see cref = "T:System.ServiceModel.Channels.Message" /> object that is returned to the client, or service, in the duplex case.</param>
        public void ProvideFault(Exception exception, MessageVersion version, ref Message fault)
        {
            FaultException faultException;

            if (exception is RuleViolationException)
            {
                faultException = CreateFaultFor((RuleViolationException)exception);
            }
            else
            {
                faultException = CreateFaultForInternalError(exception);
            }

            fault = Message.CreateMessage(version, faultException.CreateMessageFault(), faultException.Action);
        }

        private static FaultException CreateFaultFor(RuleViolationException exception)
        {
            return new FaultException<RuleViolationFault>(new RuleViolationFault(exception));
        }

        private FaultException CreateFaultForInternalError(Exception exception)
        {
            Interlocked.Increment(ref internalErrorCount);

            //// Compile a reference based on the current process' ID and a counter. The character 'S' represents
            //// an exception in one of the services.
            string errorReference = "S" + Process.GetCurrentProcess().Id + "-" + internalErrorCount;

            //logger.Error(exception, errorReference);

            var errorException = new ApplicationErrorException(Error.Internal)
            {
                {"AdministrativeReference", errorReference}
            };

            return new FaultException<ApplicationErrorFault>(new ApplicationErrorFault(errorException));
        }

        /// <summary>
        ///   Enables exception-related processing and returns a value that indicates whether subsequent HandleError implementations are called.
        /// </summary>
        /// <returns>
        ///   true if subsequent <see cref = "T:System.ServiceModel.Dispatcher.IErrorHandler" /> implementations must not be called; otherwise, false. The default is false.
        /// </returns>
        /// <param name = "exception">The exception thrown during processing.</param>
        public bool HandleError(Exception exception)
        {
            if (!(exception is CommunicationException))
            {
                return true;
            }

            var faultException = exception as FaultException;
            if (faultException != null)
            {
                //logger.Information(faultException.Message);
            }
            else
            {
                //logger.Critical(exception);
            }

            return false;
        }
    }
}