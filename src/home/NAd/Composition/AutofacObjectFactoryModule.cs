using Autofac;
using NAd.UI.Infrastructure;

namespace NAd.UI.Composition
{
    public class AutofacObjectFactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutofacObjectFactory>().AsImplementedInterfaces();
        }
    }
}