using MediatR;

namespace Application.Users.Logout;

public interface ILogoutUserCommandHandler
    : IRequestHandler<LogoutUserCommand>;
