
using System.Linq;

//using NAd.Querying.Core.Domain;
//using NAd.Querying.Core.Persistency.NHibernate;
//using NAd.Querying.Core.Persistency.NHibernate.DataServices;
using NAd.Framework.Domain;
using NHibernate;
using NHibernate.Linq;

namespace NAd.Querying.Host
{
    public class RestContext : NHibernateContext
    {
        private static readonly ISessionFactory sessionFactory;

        static RestContext()
        {
            sessionFactory = new NHibernateSessionFactoryManager().SessionFactory;
        }

        public IQueryable<Classified> Classifieds
        {
            get { return Session.Query<Classified>(); }
        }

        //public IQueryable<Product> Product
        //{
        //    get { return Session.Query<Product>(); }
        //}

        //public IQueryable<Ingredient> Ingredients
        //{
        //    get { return Session.Query<Ingredient>(); }
        //}

        protected override ISession ProvideSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}