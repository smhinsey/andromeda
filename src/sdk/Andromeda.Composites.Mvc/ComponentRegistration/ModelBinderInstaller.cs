using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Andromeda.Composites.AgentResolution;
using Andromeda.Composites.Mvc.Binders;

namespace Andromeda.Composites.Mvc.ComponentRegistration
{
	public class ModelBinderInstaller : ComponentRegistrationBase
	{
		public override void Install(IWindsorContainer container, IConfigurationStore store)
		{
			foreach (var t in GetTypesThatImplement<IAgentResolver>())
			{
				container.Register(Component.For<IAgentResolver>().ImplementedBy(t).LifeStyle.Transient);
			}

			foreach (var t in GetTypesThatImplement<IAndromedaModelBinder>())
			{
				container.Register(Component.For<IAndromedaModelBinder>().ImplementedBy(t).LifeStyle.Transient);
			}
		}
	}
}