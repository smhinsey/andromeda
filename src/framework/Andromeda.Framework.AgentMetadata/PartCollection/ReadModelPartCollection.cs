using System.Reflection;
using Andromeda.Framework.Models;

namespace Andromeda.Framework.AgentMetadata.PartCollection
{
	public class ReadModelPartCollection : PartCollectionBase<IReadModel>
	{
		public ReadModelPartCollection(Assembly agent, string readModelNamesapce)
			: base(agent, readModelNamesapce)
		{
		}

		public override string DescriptiveName
		{
			get
			{
				return "ReadModels";
			}
		}
	}
}