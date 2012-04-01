using System;
using System.Web.Mvc;
using Andromeda.Composites.AgentResolution;
using Andromeda.Composites.Extensions;
using Andromeda.Composites.Mvc.ActionFilters;
using Andromeda.Composites.Mvc.Extensions;
using Andromeda.Framework.AgentMetadata;

namespace Andromeda.Composites.Mvc.Binders
{
	public class TypeMetadataBinder : IAndromedaModelBinder
	{
		private readonly IAgentResolver[] _resolvers;

		public TypeMetadataBinder(IAgentResolver[] resolvers)
		{
			_resolvers = resolvers;
		}

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var systemName = controllerContext.GetAgentSystemName();
			if (string.IsNullOrEmpty(systemName)) return null;

			var partName = controllerContext.GetPartName();
			if (string.IsNullOrEmpty(partName)) return null;

			var metadata = _resolvers.GetAgentMetadata(systemName);

			var typeMetadata = metadata.GetPartByTypeName(partName);

			if (typeMetadata == null)
			{
				throw new TypeMetadataNotFoundException();
			}

			return typeMetadata;
		}

		public bool IsMatch(Type modelType)
		{
			return typeof(ITypeMetadata).IsAssignableFrom(modelType);
		}
	}
}