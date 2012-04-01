namespace Andromeda.Framework.EventSourcing
{
	public interface ICanApplyEvent<in TEvent>
		where TEvent : IEvent
	{
		void Apply(TEvent eventToApply);
	}
}