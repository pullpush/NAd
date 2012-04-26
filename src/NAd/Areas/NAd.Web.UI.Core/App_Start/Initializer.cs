
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using NAd.Web.UI.Core.App_Start;
using NAd.Web.UI.Core.Common;
using NAd.Web.UI.Core.Web.Mvc;
using NAd.Web.UI.Core.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Initializer), "Start")]
namespace NAd.Web.UI.Core.App_Start 
{
    public static class Initializer 
    {
        /// <summary>
        /// Initializer for NAd
        /// </summary>
        public static void Start() {

            //Insure that Autofac would inject dependecies for any ASP.NET controller created
            var container = Bootstrapper.Initialize();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            ControllerBuilder.Current.SetControllerFactory(typeof(NAdControllerFactory));

            //HostingEnvironment.RegisterVirtualPathProvider(new AmazonS3VirtualPathProvider());

            // Register the default page route
            RouteTable.Routes.RegisterPageRoute(
                container.Resolve<IPathResolver>(),
                container.Resolve<IVirtualPathResolver>());
        }
    }
}