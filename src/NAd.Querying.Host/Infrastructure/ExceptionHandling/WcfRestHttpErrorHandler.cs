using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Microsoft.ApplicationServer.Http.Dispatcher;
using NAd.Common.ExceptionHandling;

//using NAd.Querying.Core.ExceptionHandling;

namespace NAd.Querying.Host.Infrastructure.ExceptionHandling
{
    /// <summary>
    /// Global error handler
    /// <remarks>
    ///http://www.codeproject.com/Articles/43621/Extending-WCF-Part-I for pure WCF - not REST (uses FaultException)
    ///
    ///http://kenneththorman.blogspot.com/2011/02/wcf-rest-exception-handling.html
    ///http://social.msdn.microsoft.com/Forums/en-US/wcf/thread/bc73f10f-68ea-45c8-a057-2b79f7c1ae69
    ///http://www.robbagby.com/rest/effective-error-handling-with-wcf-rest/
    ///http://strepas.wordpress.com/2009/12/17/restful-error-handling/
    ///
    ///The solution:
    ///http://wcf.codeplex.com/discussions/276528
    ///http://www.tugberkugurlu.com/archive/wcf-web-api-plays-nice-with-elmah-a-quick-introduction-to-wcf-web-api-httperrorhandler
    ///
    /// </remarks>
    /// </summary>
    public class WcfRestHttpErrorHandler : HttpErrorHandler
    {
        protected override bool OnTryProvideResponse(Exception exception, ref HttpResponseMessage message)
        {
            // Notify ELMAH
            //if (exception != null)
            //    Elmah.ErrorSignal.FromCurrentContext().Raise(exception);

            // Describe our exception for the client
            var fault = new RestServiceFault {Reason = exception.Message, Exception = exception.ToString()};

            // Respond with the same request format that was used to invoke the service
            var contentType = HttpContext.Current.Request.ContentType;
            if (string.IsNullOrWhiteSpace(contentType))
                contentType = "application/json";

            // Send a serialized response to the client
            message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new ObjectContent<RestServiceFault>(fault, contentType)
            };

            return true;
        }
    }
}