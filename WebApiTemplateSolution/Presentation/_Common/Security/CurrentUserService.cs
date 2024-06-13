using Application._Common.Caching;
using Application._Common.Exceptions;
using Application._Common.Persistence.Databases;
using Application._Common.Security.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Presentation._Common.Security;

internal record CurrentUserService(
    ICacheStore CacheStore,
    IHttpContextAccessor HttpContextAccessor,
    IIdentityService IdentityService,
    IApplicationDbContext DbContext
)
    : ICurrentUserService
{
    public async Task<ICurrentUser?> GetCurrentUserAsync()
    {
        var currentUserIdentity = IdentityService.GetCurrentUserIdentity();

        if (currentUserIdentity is null)
            return null;

        var currentUserId = IdentityService
            .GetCurrentUserIdentity()?
            .Id
        ?? Guid.Empty;

        var cancellationToken = HttpContextAccessor
            .HttpContext?
            .RequestAborted
        ?? CancellationToken.None;

        var cachedCurrentUser = await CacheStore.GetAsync<CurrentUser>(
            $"{nameof(ICurrentUserIdentity)}{{{currentUserId}}}",
            cancellationToken
        );

        if (cachedCurrentUser is not null)
            return cachedCurrentUser;

        var foundUser = await DbContext
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(
                entity => entity.Id.Equals(currentUserId),
                cancellationToken
            )
        ?? throw new NotFoundException(nameof(DbContext.Users), currentUserId);

        var currentUser = new CurrentUser()
        {
            Id = currentUserId,
            Status = foundUser.Status
        };

        await CacheStore.SetAsync(
            $"{nameof(ICurrentUserIdentity)}",
            $"{nameof(ICurrentUserIdentity)}{{{currentUserId}}}",
            currentUser,
            cancellationToken
        );

        return currentUser;
    }
}