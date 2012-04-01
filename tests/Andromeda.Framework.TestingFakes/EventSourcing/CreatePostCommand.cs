using Andromeda.Framework.Cqrs;

namespace Andromeda.Framework.TestingFakes.EventSourcing
{
	public class CreatePostCommand : DefaultCommand
	{
		public string AuthorUsername { get; set; }

		public string Body { get; set; }

		public string Title { get; set; }
	}
}