using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using bookfly.Infra.Categorias.Mappings;


namespace bookfly.Infra.NHibernate
{
    public static class NHibernateSessionFactory
    {
        public static ISessionFactory Create(string connectionString)
        {
          return Fluently.Configure()
    .Database(
        PostgreSQLConfiguration.PostgreSQL82
            .ConnectionString(connectionString)
            .ShowSql()
    )
    .Mappings(m =>
        m.FluentMappings
            .AddFromAssemblyOf<CategoriaMap>()
    )
    .BuildSessionFactory();
        }
    }
}