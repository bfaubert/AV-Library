using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UI.Infrastructure.Persistence.Plumbing;

namespace UI.Infrastructure.Persistence.Installers
{
	public class PersistenceInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.AddFacility<PersistenceFacility>();
		}
	}
}