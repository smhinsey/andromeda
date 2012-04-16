using System;
using Andromeda.Common.Extensions;
using Andromeda.Common.Storage.Model;
using Andromeda.Framework.Cqrs;
using ForumAgent.Commands;
using ForumAgent.ReadModels;

namespace ForumAgent.Processors
{
	public class UpdateTagProcessor : DefaultCommandProcessor<UpdateTag>
	{
		private readonly ISimpleRepository<Tag> _tagRepository;

		public UpdateTagProcessor(ISimpleRepository<Tag> tagRepository)
		{
			_tagRepository = tagRepository;
		}

		public override void Process(UpdateTag message)
		{
			var tag = _tagRepository.FindById(message.TagIdentifier);

			if (tag == null)
			{
				throw new TagNotFoundException(string.Format("Could not update tag with id {0}", message.TagIdentifier));
			}

			tag.Name = message.Name.Slugify();
			tag.Active = message.Active;
			tag.Modified = DateTime.Now;

			_tagRepository.Update(tag);
		}
	}
}