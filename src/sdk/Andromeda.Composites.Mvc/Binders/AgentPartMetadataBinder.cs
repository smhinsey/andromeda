using System;
using System.Web.Mvc;
using Andromeda.Composites.AgentResolution;
using Andromeda.Composites.Extensions;
using Andromeda.Composites.Mvc.ActionFilters;
using Andromeda.Composites.Mvc.Extensions;
using Andromeda.Framework.AgentMetadata;

namespace Andromeda.Composites.Mvc.Binders
{
	public class AgentPartMetadataBinder : IAndromedaModelBinder
	{
		private readonly IAgentResolver[] _resolvers;

		public AgentPartMetadataBinder(IAgentResolver[] resolvers)
		{
			_resolvers = resolvers;
		}

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var systemName = controllerContext.GetAgentSystemName();

			var partName = controllerContext.GetPartName();

			var metadata = _resolvers.GetAgentMetadata(systemName);

			var agentPartMetadata = metadata.GetPartByTypeName(partName);

			if (agentPartMetadata == null)
			{
				throw new TypeMetadataNotFoundException();
			}

			return agentPartMetadata;
		}

		public bool IsMatch(Type modelType)
		{
			return typeof(IAgentPart).IsAssignableFrom(modelType);
		}
	}
}