using Application._Common.Exceptions;
using Application._Common.Security.Authentication;
using Application._Common.Security.Authorization;
using Application._Security.Users.ChangePassword;
using Domain._Security.Users;
using MediatR;
using System.Reflection;

namespace Infrastructure._Common.Behaviors;

internal class AuthorizationBehavior<TRequest, TResponse>(
    IIdentityService identityService,
    ICurrentUserService currentUserService
)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (IsAnonymousCall(request))
            return await next();

        await ValidateUserStatusAsync(request);

        return await next();
    }

    private static bool IsAnonymousCall(TRequest request)
    {
        var allowAnonymousAttribute = request
            .GetType()
            .GetCustomAttribute<AllowAnonymousAttribute>();

        return allowAnonymousAttribute is not null;
    }
    private async Task ValidateUserStatusAsync(TRequest request)
    {
        if (identityService.IsCurrentUserNotAuthenticated())
            throw new UnauthorizedAccessException();

        var currentUser = await currentUserService
            .GetCurrentUserAsync()
        ?? throw new UnauthorizedAccessException();

        if (currentUser.Status is UserStatus.RequiredPasswordChange && request is not ChangeUserPasswordCommand)
            throw new PasswordChangeRequiredException();
    }
}
