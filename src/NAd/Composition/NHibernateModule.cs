using System.Collections.Generic;
using Autofac;
using NAd.UI.Infrastructure;
using NHibernate;
using NHibernate.Cfg;

namespace NAd.UI.Composition
{
    public class NHibernateModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var cfg = new Configuration().Configure();
            cfg.AddProperties(new Dictionary<string, string>
                                  {
                                      {"current_session_context_class", "NHibernate.Context.WebSessionContext"}
                                  });
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            builder.RegisterInstance(sessionFactory);
            builder.RegisterType<NHibernateAmbientSessionManager>().AsSelf();
        }
    }
}