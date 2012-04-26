﻿
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using NAd.Web.UI.Core.Configuration;

namespace NAd.Web.UI.Core.Web.Mvc
{
    public class NAdControllerFactory : DefaultControllerFactory {
        
        //private readonly IDocumentSession _session;
        private static bool _hasConfiguration;

        /// <summary>
        /// Creates the specified controller by using the specified request context.
        /// </summary>
        /// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <returns>
        /// The controller.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="requestContext"/> parameter is null.</exception>
        ///   
        /// <exception cref="T:System.ArgumentException">The <paramref name="controllerName"/> parameter is null or empty.</exception>
        public override IController CreateController(RequestContext requestContext, string controllerName) {
            if (!HasConfiguration()) {
                requestContext.RouteData.DataTokens["area"] = "dashboard";
                requestContext.RouteData.Values["action"] = "index";
                requestContext.RouteData.Values["controller"] = "setup";

                return base.CreateController(requestContext, "setup");
            }

            return base.CreateController(requestContext, controllerName);
        }
        /// <summary>
        /// Determines whether this instance has configuration.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has configuration; otherwise, <c>false</c>.
        /// </returns>
        private bool HasConfiguration() {
            if(!_hasConfiguration) {
                //var configuration = _session.Load<IConfiguration>("brickpile/configuration");
                //_hasConfiguration = configuration != null;
                _hasConfiguration = true;
            }
            return _hasConfiguration;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="NAdControllerFactory"/> class.
        /// </summary>
        public NAdControllerFactory() {
            //_session = ObjectFactory.GetInstance<IDocumentSession>();
        }
    }
}