namespace Application.Users;

public record UserChangedEvent
    : IEvent
{
    public required Guid UserId { get; init; }
}

