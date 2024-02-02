using Application._Common.Commands;
using Application._Common.Security.Authorization;

namespace Application._Security.Users.ResetPassword;

[AllowAnonymous]
public record ResetUserPasswordCommand
    : ICommand
{
    public required Guid Id { get; init; }
}
