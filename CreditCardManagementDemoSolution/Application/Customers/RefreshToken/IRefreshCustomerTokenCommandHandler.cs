using MediatR;

namespace Application.Customers.RefreshToken;

public interface IRefreshCustomerTokenCommandHandler
    : IRequestHandler<RefreshCustomerTokenCommand, RefreshCustomerTokenCommandResponse>
{ }