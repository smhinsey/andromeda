using Andromeda.Composites.Mvc.Models;
using Andromeda.Sdk.TestAgent.Commands;

namespace Andromeda.Sdk.TestComposite.Models
{
	public class ComplexInputModel : DefaultInputModel
	{
		public ComplexInputModel()
		{
			CommandType = typeof (ComplexCommand);
		}

		public string StringValue { get; set; }
	}
}