﻿using System;
using Andromeda.Composites.Mvc.Models;
using ForumAgent.Commands;

namespace AdminComposite.Areas.Forum.InputModels
{
	public class ActivateUserInputModel : DefaultInputModel
	{
		public ActivateUserInputModel()
		{
			CommandType = typeof (ActivateForumUser);
		}

		public Guid UserIdentifier { get; set; }
		public bool Active { get; set; }
	}
}