using System;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;

namespace NAd.UI.Infrastructure
{
    /// <summary>
    /// A controller factory based on ambient DI container.
    /// </summary>
    public class ContainerControllerFactory : DefaultControllerFactory
    {
        private readonly IContainer _container;

        public ContainerControllerFactory(IContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)_container.Resolve(controllerType);
        }
    }
}