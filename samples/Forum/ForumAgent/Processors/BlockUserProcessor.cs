﻿using System;
using Andromeda.Common.Messaging;
using Andromeda.Common.Storage.Model;
using Andromeda.Framework.Cqrs;
using ForumAgent.Commands;
using ForumAgent.ReadModels;

namespace ForumAgent.Processors
{
	public class BlockUserProcessor : DefaultCommandProcessor<BlockUser>
	{
		private readonly ISimpleRepository<ForumUser> _userRepository;

		public BlockUserProcessor(ISimpleRepository<ForumUser> userRepository)
		{
			_userRepository = userRepository;
		}

		public override void Process(BlockUser message)
		{
			var user = _userRepository.FindById(message.UserIdentifier);
			user.IsBlocked = true;
			user.Active = false;
			user.Modified = DateTime.Now;
			_userRepository.Update(user);
		}
	}
}