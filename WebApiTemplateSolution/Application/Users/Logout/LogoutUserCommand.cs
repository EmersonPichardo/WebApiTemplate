using Application._Common.Security.Authorization;

namespace Application.Users.Logout;

[AllowAnonymous]
public record LogoutUserCommand
    : ICommand
{
    public required Guid UserId { get; init; }
}
