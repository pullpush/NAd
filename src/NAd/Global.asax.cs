using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Autofac;
using Autofac.Integration.Mvc;

using NAd.UI.Composition;
using NAd.UI.Infrastructure;


namespace NAd.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class Global : System.Web.HttpApplication
    {
        //private static NHibernateAmbientSessionManager _ambientSessionManager;


        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public override void Init()
        {
            base.Init();
            WireUpSessionLifecycle();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);

            RouteRegistrar.RegisterRoutes(RouteTable.Routes);
            ComposeApplication();
        }


        private static void ComposeApplication()
        {
            IContainer container = null;
            var containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterModule<ApplicationServicesModule>();
            //containerBuilder.RegisterModule<RepositoryModule>();
            //containerBuilder.RegisterModule<NHibernateModule>();
            //containerBuilder.RegisterModule<EventPublisherModule>();
            containerBuilder.RegisterModule<AutofacObjectFactoryModule>();
            //containerBuilder.RegisterModule<CommandFilterModule>();
            containerBuilder.RegisterModule<ControllerModule>();
            containerBuilder.RegisterModule<FacadeModule>();
            //containerBuilder.RegisterModule<DTOAssemblerModule>();
            //containerBuilder.RegisterModule<ExternalServicesModule>();

            containerBuilder.Register(x => container);

            container = containerBuilder.Build();

            //_ambientSessionManager = container.Resolve<NHibernateAmbientSessionManager>();
            ControllerBuilder.Current.SetControllerFactory(new ContainerControllerFactory(container));

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


        private void WireUpSessionLifecycle()
        {
            //PreRequestHandlerExecute += (sender, e) => _ambientSessionManager.CreateAndBind();
            //PostRequestHandlerExecute += (sender1, e1) => _ambientSessionManager.UnbindAndDispose();
        }
    }
}