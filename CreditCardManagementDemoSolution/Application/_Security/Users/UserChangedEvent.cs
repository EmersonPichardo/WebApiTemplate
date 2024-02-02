using Application._Common.Events;

namespace Application._Security.Users;

public record UserChangedEvent
    : IEvent
{
    public required Guid UserId { get; init; }
}

