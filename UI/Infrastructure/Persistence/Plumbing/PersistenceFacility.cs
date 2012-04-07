using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using Core.Domain.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace UI.Infrastructure.Persistence.Plumbing
{
	public class PersistenceFacility : AbstractFacility
	{
		protected override void Init()
		{
			var config = BuildDatabaseConfiguration();

			Kernel.Register(
				Component.For<ISessionFactory>()
					.UsingFactoryMethod(_ => config.BuildSessionFactory()),
				Component.For<ISession>()
					.UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
					.LifeStyle.PerWebRequest
				);
		}

		private NHibernate.Cfg.Configuration BuildDatabaseConfiguration()
		{
			return Fluently.Configure()
				.Database(SetupDatabase)
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Movie>())
                .ExposeConfiguration(ConfigurePersistence)
				.BuildConfiguration();
		}

		protected virtual IPersistenceConfigurer SetupDatabase()
		{
			return MsSqlConfiguration.MsSql2008
				.ConnectionString(x => x.FromConnectionStringWithKey("ApplicationServices"))
				.ShowSql();
		}

        protected virtual void ConfigurePersistence(NHibernate.Cfg.Configuration config)
        {
            SchemaMetadataUpdater.QuoteTableAndColumns(config);
        }
	}
}