using Andromeda.Framework.Cqrs;

namespace Andromeda.TestingSupport
{
	public interface ICommandPublishStep<T>
		where T : ICommand
	{
		T GetCommand(T command);
	}
}