using System.Web.Mvc;
using Andromeda.Framework.AgentMetadata;

namespace Andromeda.Composites.Mvc.ActionFilters
{
	public class FormatAgentMetadata : MetadataFormatterAttributeBase
	{
		public override IMetadataFormatter GetFormatter(ActionExecutingContext filterContext)
		{
			return filterContext.ActionParameters["agentMetadata"] as IMetadataFormatter;
		}
	}
}