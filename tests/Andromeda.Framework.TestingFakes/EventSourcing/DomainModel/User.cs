using System.Collections.Generic;
using Andromeda.Framework.EventSourcing;

namespace Andromeda.Framework.TestingFakes.EventSourcing.DomainModel
{
	public class User : DefaultEventSourcedAggregate
	{
		public virtual IList<Post> Posts { get; set; }

		public virtual string Username { get; set; }
	}
}