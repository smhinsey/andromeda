using Andromeda.Common.Storage.Model;
using Andromeda.Framework.Cqrs;
using ForumAgent.Commands;
using ForumAgent.ReadModels;

namespace ForumAgent.Processors
{
	public class RejectPostProcessor : DefaultCommandProcessor<RejectPost>
	{
		private readonly ISimpleRepository<ModeratedPost> _repository;

		public RejectPostProcessor(ISimpleRepository<ModeratedPost> repository)
		{
			_repository = repository;
		}

		public override void Process(RejectPost message)
		{
			_repository.Delete(message.PostIdentifier);
		}
	}
}