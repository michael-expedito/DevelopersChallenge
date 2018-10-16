using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using TorneioNIBO.Infra.Data.Mapping;

namespace TorneioNIBO.Infra.Data.Database
{
    public class FluentSessionFactory
    {
        private static string ConnectionString = "Server=localhost; Port=5432; User Id=postgres; Password=root; Database=nibo-prod";


        private static ISessionFactory session;

        public static ITransaction Transaction { get; set; }

        public static ISessionFactory CreateSession()
        {
            if (session != null)
            {
                return session;
            }
            IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
            var configMap = Fluently.Configure().Database(configDB).Mappings(x => x.FluentMappings.AddFromAssemblyOf<TeamMap>());
            session = configMap.BuildSessionFactory();
            return session;
        }

        public static ISession OpenSession()
        {
            return CreateSession().OpenSession();
        }
    }
}
