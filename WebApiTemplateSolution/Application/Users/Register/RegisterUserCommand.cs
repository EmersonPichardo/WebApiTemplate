using Application._Common.Security.Authorization;

namespace Application.Users.Register;

[AllowAnonymous]
public record RegisterUserCommand
    : ICommand
{
    public required string FullName { get; init; }
    public required string Email { get; init; }
}
