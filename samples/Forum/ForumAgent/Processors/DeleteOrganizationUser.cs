using System;
using Andromeda.Common.Storage.Model;
using Andromeda.Framework.Cqrs;
using ForumAgent.Commands;
using ForumAgent.Domain.Entities;

namespace ForumAgent.Processors
{
	public class DeleteOrganizationUserProcessor : DefaultCommandProcessor<DeleteOrganizationUser>
	{
		private readonly ISimpleRepository<OrganizationUserEntity> _repository;

		public DeleteOrganizationUserProcessor(ISimpleRepository<OrganizationUserEntity> repository)
		{
			_repository = repository;
		}

		public override void Process(DeleteOrganizationUser message)
		{
			_repository.Delete(message.UserIdentifier);
		}
	}
}