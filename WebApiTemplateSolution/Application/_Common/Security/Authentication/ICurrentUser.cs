using Domain._Security.Users;

namespace Application._Common.Security.Authentication;

public interface ICurrentUser : ICurrentUserIdentity
{
    UserStatus Status { get; init; }
}