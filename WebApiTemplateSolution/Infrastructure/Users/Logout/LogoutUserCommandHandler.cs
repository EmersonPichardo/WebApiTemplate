using Application._Common.Caching;
using Application._Common.Security.Authentication;
using Application.Users.Logout;

namespace Infrastructure.Users.Logout;

internal class LogoutUserCommandHandler(
    ICacheStore cacheStore
)
    : ILogoutUserCommandHandler
{
    public async Task Handle(LogoutUserCommand command, CancellationToken cancellationToken)
    {
        await cacheStore.ClearAsync(
            $"{nameof(ICurrentUserIdentity)}{{{command.UserId}}}",
            cancellationToken
        );
    }
}
