using System;
using System.Data.SqlClient;

using NAd.Common;
using NAd.Querying.Core.Domain;

using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Instances;

using HibernatingRhinos.Profiler.Appender.NHibernate;

using NHibernate;
//using NHibernate.ByteCode.Castle;

using System.Configuration;

using NHibernate.Tool.hbm2ddl;

namespace NAd.Querying.Core.Persistency.NHibernate
{
    public class NHibernateSessionFactoryManager
    {
        private FluentConfiguration fluentConfiguration;
        private ISessionFactory cachedSessionFactory;
        private readonly string connectionString ;

        public NHibernateSessionFactoryManager() :
            this(ConfigurationManager.ConnectionStrings["QueryContext"].ConnectionString)
        {
            
        }

        public NHibernateSessionFactoryManager(string connectionString)
        {
            this.connectionString = connectionString;
            InitializeFluentConfiguration();
        }
        
        private void InitializeFluentConfiguration()
        {
            fluentConfiguration = Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(connectionString))
                    //.CurrentSessionContext("web")
                    //.ProxyFactoryFactory(typeof (ProxyFactoryFactory).AssemblyQualifiedName))
                .Mappings(m => m.AutoMappings.Add(AutoMap
                    .AssemblyOf<Entity>(new AutoMappingConfiguration())
                    .UseOverridesFromAssemblyOf<Entity>()
                    .Conventions.Add(
                        ForeignKey.EndsWith(DatabaseConstants.IdentitySuffix),
                        Table.Is(x => x.EntityType.Name.Pluralize()),
                        OptimisticLock.Is(x => x.Version()),
                        new DiscriminatorConvention())));
        }

        public ISessionFactory SessionFactory
        {
            get
            {
                if (cachedSessionFactory == null)
                {
                    if (EnableProfiling)
                    {
                        NHibernateProfiler.Initialize();
                        fluentConfiguration.ExposeConfiguration(cfg => cfg.SetProperty("generate_statistics", "true"));
                    }

                    cachedSessionFactory = fluentConfiguration.BuildSessionFactory();
                }

                return cachedSessionFactory;
            }
        }

        private static bool EnableProfiling
        {
            get
            {
                string value = ConfigurationManager.AppSettings["EnableProfiling"];
                return value.IsNotNullOrEmpty() && (value.ToLower() == "true");
            }
        }

        public bool DatabaseExists()
        {
            using (SqlConnection connection = CreateConnectionToMasterDatabase())
            {
                var command = new SqlCommand(@"SELECT db_id('" + DatabaseName + "')", connection);

                object id = command.ExecuteScalar();

                return (id != DBNull.Value);
            }
        }

        public void CreateDatabase()
        {
            using (SqlConnection connection = CreateConnectionToMasterDatabase())
            {
                var myCommand = new SqlCommand(@"CREATE DATABASE " + DatabaseName, connection);

                myCommand.ExecuteNonQuery();

                new SchemaExport(fluentConfiguration.BuildConfiguration()).Execute(true, true, false);
            }
        }

        private SqlConnection CreateConnectionToMasterDatabase()
        {
            var builder = new SqlConnectionStringBuilder(connectionString) { InitialCatalog = "master" };

            var connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            return connection;
        }

        private string DatabaseName
        {
            get
            {
                var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                return connectionStringBuilder.InitialCatalog;
            }
        }

        private class DiscriminatorConvention : ISubclassConvention
        {
            public void Apply(ISubclassInstance instance)
            {
                instance.DiscriminatorValue(instance.EntityType.Name);
            }
        }
    }
}