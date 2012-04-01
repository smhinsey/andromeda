using System.Reflection;
using Andromeda.Framework.Cqrs;

namespace Andromeda.Framework.AgentMetadata.PartCollection
{
	public class QueryPartCollection : PartCollectionBase<IQuery>
	{
		public QueryPartCollection(Assembly agent, string queryNamespace)
			: base(agent, queryNamespace)
		{
		}

		public override string DescriptiveName
		{
			get
			{
				return "Queries";
			}
		}
	}
}