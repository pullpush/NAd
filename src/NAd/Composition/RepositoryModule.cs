using Autofac;
using System;
//using NAd.Persistence.NHibernate;

namespace NAd.UI.Composition
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            throw new NotImplementedException();
            //builder.RegisterAssemblyTypes(typeof(GenericRepository).Assembly)
            //    .Where(x => x.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces();
        }
    }
}