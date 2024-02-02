using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Infrastructure._Common.Behaviors;

internal class PerformanceBehavior<TRequest, TResponse>(
    ILogger<TRequest>? logger
)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly Stopwatch timer = new();

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        timer.Start();
        var response = await next();
        timer.Stop();

        var milliseconds = timer.ElapsedMilliseconds;

        if (milliseconds > 750)
            await LogPerformanceIssue(milliseconds);

        return response;
    }

    private async Task LogPerformanceIssue(long elapsedMilliseconds)
    {
        logger?.LogWarning("Long running request: {@RequestName}({@Milliseconds}ms)",
            typeof(TRequest).Name,
            elapsedMilliseconds
        );

        await Task.CompletedTask;
    }
}