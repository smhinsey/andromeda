﻿using System;
using Euclid.Composites.Mvc.Models;

namespace AdminComposite.Areas.Forum.InputModels
{
	public class RejectCommentInputModel : DefaultInputModel
	{
		public Guid CreatedBy { get; set; }
		public Guid PostIdentifier { get; set; }
	}
}