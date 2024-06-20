using Application._Common.Security.Authorization;

namespace Application.Users.ResetPassword;

[AllowAnonymous]
public record ResetUserPasswordCommand
    : ICommand
{
    public required Guid Id { get; init; }
}
