using Application._Common.Security.Authentication;
using Domain._Security.Users;

namespace Presentation._Common.Security;

internal class CurrentUser : ICurrentUser
{
    public required Guid Id { get; init; }
    public required UserStatus Status { get; init; }
}