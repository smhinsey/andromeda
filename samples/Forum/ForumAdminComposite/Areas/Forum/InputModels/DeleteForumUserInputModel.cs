using System;
using Andromeda.Composites.Mvc.Models;
using ForumAgent.Commands;

namespace AdminComposite.Areas.Forum.InputModels
{
	public class DeleteForumUserInputModel : DefaultInputModel
	{
		public DeleteForumUserInputModel()
		{
			CommandType = typeof (DeleteForumUser);
		}

		public Guid UserIdentifier { get; set; }
	}
}