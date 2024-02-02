using Application._Common.Events;

namespace Infrastructure._Common.Events;

internal class EventPublisher : IEventPublisher
{
    private readonly List<IEvent> events = [];

    public void AddEvent(IEvent @event)
        => events.Add(@event);

    public IReadOnlyCollection<IEvent> GetEvents()
        => events.AsReadOnly();

    public bool HasEvents()
        => events.Count > 0;

    public bool NotHasEvents()
        => !HasEvents();
}
