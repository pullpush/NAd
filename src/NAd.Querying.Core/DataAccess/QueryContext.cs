
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;

using NHibernate;
//using NHibernate.ByteCode.Castle;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;

namespace NAd.Querying.Core.DataAccess
{
    public class QueryContext : NHibernateContext
    {
        private static readonly FluentConfiguration configuration;
        private static ISessionFactory sessionFactory;
        private static readonly string connectionString;
        private static readonly string databaseName;

        static QueryContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QueryContext"].ConnectionString;

            var builder = new SqlConnectionStringBuilder(connectionString);
            databaseName = builder.InitialCatalog;

            configuration = Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(connectionString))
                    //.ProxyFactoryFactory(typeof (ProxyFactoryFactory).AssemblyQualifiedName))
                .Mappings(m => m.AutoMappings.Add(AutoMap
                    .AssemblyOf<QueryContext>()
                    .Where(x => typeof (Entity).IsAssignableFrom(x))
                    .UseOverridesFromAssemblyOf<QueryContext>()
                    .Conventions.Add(
                        ForeignKey.EndsWith("Id"),
                        Table.Is(x => Inflector.Pluralize(x.EntityType.Name)))));
        }

        public IQueryable<Classified> Classifieds
        {
            get { return Session.Query<Classified>(); }
        }

        protected override ISession ProvideSession()
        {
            return SessionFactory.OpenSession();
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    sessionFactory = configuration.BuildSessionFactory();
                }

                return sessionFactory;
            }
        }

        public void Add(Classified classified)
        {
            Session.Save(classified);
        }

        public bool DatabaseExists()
        {
            using (SqlConnection connection = CreateConnectionToMasterDatabase())
            {
                var command = new SqlCommand(@"SELECT db_id('" + databaseName + "')", connection);

                object id = command.ExecuteScalar();

                return (id != DBNull.Value);
            }
        }

        public void CreateDatabase()
        {
            using (SqlConnection connection = CreateConnectionToMasterDatabase())
            {
                var myCommand = new SqlCommand(@"CREATE DATABASE " + databaseName, connection);

                myCommand.ExecuteNonQuery();

                new SchemaExport(configuration.BuildConfiguration()).Execute(true, true, false);
            }
        }

        private static SqlConnection CreateConnectionToMasterDatabase()
        {
            var builder = new SqlConnectionStringBuilder(connectionString) {InitialCatalog = "master"};

            var connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            return connection;
        }
    }
}