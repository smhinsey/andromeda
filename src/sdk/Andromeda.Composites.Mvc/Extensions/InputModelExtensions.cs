using Andromeda.Framework.AgentMetadata;
using Andromeda.Framework.AgentMetadata.Formatters;
using Andromeda.Framework.Models;

namespace Andromeda.Composites.Mvc.Extensions
{
	public static class InputModelExtensions
	{
		public static IMetadataFormatter GetMetadataFormatter(this IInputModel inputModel)
		{
			return new InputModelFormatter(inputModel);
		}
	}
}