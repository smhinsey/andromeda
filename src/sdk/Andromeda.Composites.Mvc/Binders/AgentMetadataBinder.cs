using System;
using System.Web.Mvc;
using Andromeda.Composites.AgentResolution;
using Andromeda.Composites.Extensions;
using Andromeda.Composites.Mvc.Extensions;
using Andromeda.Framework.AgentMetadata;

namespace Andromeda.Composites.Mvc.Binders
{
	public class AgentMetadataBinder : IAndromedaModelBinder
	{
		private readonly IAgentResolver[] _resolvers;

		public AgentMetadataBinder(IAgentResolver[] resolvers)
		{
			_resolvers = resolvers;
		}

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var systemName = controllerContext.GetAgentSystemName();

			return _resolvers.GetAgentMetadata(systemName);
		}

		public bool IsMatch(Type modelType)
		{
			return modelType == typeof(IAgentMetadata);
		}
	}
}