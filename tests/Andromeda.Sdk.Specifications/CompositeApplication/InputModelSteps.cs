using System;
using System.Collections.Generic;
using Andromeda.Sdk.TestAgent.Commands;
using Andromeda.Sdk.TestAgent.Queries;
using Andromeda.Sdk.TestAgent.ReadModels;
using Andromeda.TestingSupport;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Andromeda.Sdk.Specifications.CompositeApplication
{
	[Binding]
	[StepScope(Feature = "Publish input models as commands")]
	public class InputModelSteps : DefaultAgentSteps, IValidateListOfReadModels<TestQuery, TestReadModel>
	{
		public InputModelSteps()
		{
			Initialize();
		}

		protected override Type TypeFromAgent
		{
			get
			{
				return typeof(TestCommand);
			}
		}

		public void ValidateList(TestQuery query, IList<TestReadModel> readModels)
		{
			Assert.Greater(readModels.Count, 0);
		}
	}
}