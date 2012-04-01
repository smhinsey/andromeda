using Andromeda.Framework.Models;

namespace Andromeda.Framework.TestingFakes.Cqrs
{
	public class FakeReadModel : DefaultReadModel
	{
		public virtual string Message { get; set; }
	}
}