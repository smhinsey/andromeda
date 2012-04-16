using System;
using System.Data.SqlTypes;
using Andromeda.Common.Storage.Model;
using Andromeda.Framework.Cqrs;
using ForumAgent.Commands;
using ForumAgent.ReadModels;

namespace ForumAgent.Processors
{
	public class AddForumUserAsFriendProcessor : DefaultCommandProcessor<AddForumUserAsFriend>
	{
		private readonly ISimpleRepository<ForumUser> _userRepository;
		private readonly ISimpleRepository<ForumUserFriend> _userFriendRepository;

		public AddForumUserAsFriendProcessor(ISimpleRepository<ForumUser> userRepository, ISimpleRepository<ForumUserFriend> userFriendRepository)
		{
			_userRepository = userRepository;
			_userFriendRepository = userFriendRepository;
		}

		public override void Process(AddForumUserAsFriend message)
		{
			var friendProfile = _userRepository.FindById(message.FriendIdentifier);

			var friend = new ForumUserFriend()
				{
					Created = DateTime.Now, 
					Modified = (DateTime)SqlDateTime.MinValue,
					ForumIdentifier = message.ForumIdentifier,
					UserIdentifier = message.UserIdentifier,
					FriendUsername = friendProfile.Username,
					FriendIdentifier = friendProfile.Identifier
				};

			_userFriendRepository.Save(friend);
		}
	}
}