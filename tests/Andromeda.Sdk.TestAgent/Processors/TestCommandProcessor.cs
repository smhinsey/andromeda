using System;
using Andromeda.Common.Logging;
using Andromeda.Common.Storage.Model;
using Andromeda.Framework.Cqrs;
using Andromeda.Sdk.TestAgent.Commands;
using Andromeda.Sdk.TestAgent.Queries;
using Andromeda.Sdk.TestAgent.ReadModels;

namespace Andromeda.Sdk.TestAgent.Processors
{
	public class TestCommandProcessor : DefaultCommandProcessor<TestCommand>
	{
		private readonly TestQuery _query;

		private readonly ISimpleRepository<TestReadModel> _repository;

		public TestCommandProcessor(TestQuery query, ISimpleRepository<TestReadModel> repository)
		{
			_query = query;
			_repository = repository;
		}

		public override void Process(TestCommand message)
		{
			this.WriteInfoMessage("Command no. {0} was processed by TestCommandProcessor", message.Number);

			var model = new TestReadModel
				{ Identifier = Guid.NewGuid(), Number = message.Number, Created = DateTime.Now, Modified = DateTime.Now };

			_repository.Save(model);
		}
	}
}