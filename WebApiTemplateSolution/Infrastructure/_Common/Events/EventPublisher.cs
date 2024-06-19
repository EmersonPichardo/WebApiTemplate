using Application._Common.Events;
using System.Collections.Concurrent;

namespace Infrastructure._Common.Events;

internal class EventPublisher : IEventPublisher
{
    private readonly ConcurrentQueue<IEvent> _events = [];

    public void EnqueueEvent(IEvent @event)
        => _events.Enqueue(@event);

    public void EnqueueEvents(IEnumerable<IEvent> events)
    {
        foreach (var @event in events)
            _events.Enqueue(@event);
    }

    public bool TryDequeueEvent(out IEvent? @event)
        => _events.TryDequeue(out @event);

    public bool HasPendingEvents()
        => _events.IsEmpty;
}
