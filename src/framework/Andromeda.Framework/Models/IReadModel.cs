using Andromeda.Common.Storage;
using Andromeda.Framework.AgentMetadata;

namespace Andromeda.Framework.Models
{
	/// <summary>
	/// 	The basic contract for defining a read model, or a view of an aggregate which is optimized
	/// 	for use in a composite user interface such as an MVC application.
	/// </summary>
	public interface IReadModel : IModel, IAgentPart
	{
	}
}