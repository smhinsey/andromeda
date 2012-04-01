using Andromeda.Composites.Mvc.Models;
using Andromeda.Sdk.TestAgent.Commands;

namespace Andromeda.Sdk.TestComposite.Models
{
	public class TestInputModel : DefaultInputModel
	{
		public TestInputModel()
		{
			CommandType = typeof (TestCommand);
		}

		public int Number { get; set; }
	}
}