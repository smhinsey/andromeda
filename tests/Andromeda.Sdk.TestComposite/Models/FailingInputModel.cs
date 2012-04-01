using Andromeda.Composites.Mvc.Models;
using Andromeda.Sdk.TestAgent.Commands;

namespace Andromeda.Sdk.TestComposite.Models
{
	public class FailingInputModel : DefaultInputModel
	{
		public FailingInputModel()
		{
			CommandType = typeof(FailingCommand);
		}
	}
}