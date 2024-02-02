using MediatR;

namespace Application.Customers.Login;

public interface ILoginCustomerCommandHandler
    : IRequestHandler<LoginCustomerCommand, LoginCustomerCommandResponse>
{ }