using Application._Common.Events;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Infrastructure._Common.Behaviors;

internal class EventBehavior<TRequest, TResponse>(
    ILogger<TRequest>? logger,
    IPublisher publisher,
    IEventPublisher eventPublisher
)
    : IRequestPostProcessor<TRequest, TResponse>
    where TRequest : IBaseRequest
{
    public Task Process(
        TRequest request,
        TResponse response,
        CancellationToken cancellationToken)
    {
        if (eventPublisher.NotHasEvents())
            return Task.CompletedTask;

        var events = eventPublisher.GetEvents();

        foreach (var @event in events)
            PublishEventInBackground(@event, cancellationToken);

        return Task.CompletedTask;
    }

    private Task PublishEventInBackground(IEvent @event, CancellationToken cancellationToken)
    {
        return Task.Run(
            async () => await publisher
                .Publish(@event, cancellationToken)
                .ConfigureAwait(false),
            cancellationToken
        )
        .ContinueWith(
            task =>
            {
                if (!task.IsFaulted)
                    return;

                if (task.Exception is null)
                {
                    logger?.LogError("Error processing event {@EventName}",
                        @event.GetType().Name
                    );

                    return;
                }

                logger?.LogError(task.Exception, "Error processing event {@EventName} {@ExceptionMessage}",
                    @event.GetType().Name,
                    task.Exception.Message
                );
            },
            cancellationToken
        );
    }
}