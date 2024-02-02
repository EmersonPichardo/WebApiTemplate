using Application._Common.Commands;
using Application._Common.Security.Authorization;

namespace Application.Customers.RefreshToken;

[AllowAnonymous]
public record RefreshCustomerTokenCommand()
    : ICommand<RefreshCustomerTokenCommandResponse>;