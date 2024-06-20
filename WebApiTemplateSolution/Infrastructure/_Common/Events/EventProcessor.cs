using Application._Common.Events;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace Infrastructure._Common.Events;

internal class EventProcessor(
    IEventPublisher eventPublisher,
    IPublisher publisher
)
    : BackgroundService
{
    private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(5));

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (
            !stoppingToken.IsCancellationRequested &&
            await _timer.WaitForNextTickAsync(stoppingToken)
        )
        {
            if (
                eventPublisher.HasNoPendingEvents() ||
                !eventPublisher.TryDequeueEvent(out var @event) ||
                @event is null
            )
                continue;

            await publisher.Publish(@event, stoppingToken);
        }
    }
}
