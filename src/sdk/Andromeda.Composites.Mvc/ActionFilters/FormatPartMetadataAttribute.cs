using System.Web.Mvc;
using Andromeda.Framework.AgentMetadata;

namespace Andromeda.Composites.Mvc.ActionFilters
{
	public class FormatPartMetadataAttribute : MetadataFormatterAttributeBase
	{
		public override IMetadataFormatter GetFormatter(ActionExecutingContext filterContext)
		{
			var partMetadata = filterContext.ActionParameters["typeMetadata"] as ITypeMetadata;

			if (partMetadata == null)
			{
				throw new AgentPartMetdataNotFoundException();
			}

			return partMetadata.GetFormatter();
		}
	}
}