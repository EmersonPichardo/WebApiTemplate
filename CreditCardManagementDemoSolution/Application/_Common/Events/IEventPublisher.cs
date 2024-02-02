namespace Application._Common.Events;

public interface IEventPublisher
{
    void AddEvent(IEvent @event);
    IReadOnlyCollection<IEvent> GetEvents();
    bool HasEvents();
    bool NotHasEvents();
}
