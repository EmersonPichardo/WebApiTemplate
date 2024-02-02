using MediatR;

namespace Application._Security.Users.ResetPassword;

public interface IResetUserPasswordCommandHandler
    : IRequestHandler<ResetUserPasswordCommand>
{ }
