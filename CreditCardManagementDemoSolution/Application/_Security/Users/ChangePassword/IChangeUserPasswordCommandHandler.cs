using MediatR;

namespace Application._Security.Users.ChangePassword;

public interface IChangeUserPasswordCommandHandler
    : IRequestHandler<ChangeUserPasswordCommand>
{ }