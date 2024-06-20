using MediatR;

namespace Application.Users.Register;

public interface IRegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand>
{ }
