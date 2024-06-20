using Domain.Security;

namespace Application.Users.Login;

public record UserLoggedInEvent
    : IEvent
{
    public required User User { get; init; }
}
