namespace Application.Users.Register;

public record UserRegisteredEvent
    : IEvent
{
    public required Guid UserId { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}
