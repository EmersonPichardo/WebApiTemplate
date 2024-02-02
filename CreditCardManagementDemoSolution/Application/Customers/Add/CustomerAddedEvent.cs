using Application._Common.Events;

namespace Application.Customers.Add;

public record CustomerAddedEvent
    : IEvent
{
    public required string CustomerEmail { get; init; }
    public required string UserFullName { get; init; }
    public required string UserPassword { get; init; }
}