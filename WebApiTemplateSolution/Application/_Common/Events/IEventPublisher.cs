namespace Application._Common.Events;

public interface IEventPublisher
{
    void EnqueueEvent(IEvent @event);
    void EnqueueEvents(IEnumerable<IEvent> events);
    bool TryDequeueEvent(out IEvent? @event);
    bool HasPendingEvents();
    bool HasNoPendingEvents() => !HasPendingEvents();
}
