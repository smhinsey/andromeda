using Andromeda.Composites;
using TechTalk.SpecFlow;

namespace Andromeda.Sdk.Specifications.Metadata.Composite
{
	public class CompositeTestProperties : PropertiesUsedInTests
	{
		protected ICompositeApp Composite
		{
			get
			{
				return ScenarioContext.Current["composite"] as ICompositeApp;
			}
			set
			{
				ScenarioContext.Current["composite"] = value;
			}
		}

		protected bool IsValid
		{
			get
			{
				return (bool)ScenarioContext.Current["hasErrors"];
			}
			set
			{
				ScenarioContext.Current["hasErrors"] = value;
			}
		}
	}
}