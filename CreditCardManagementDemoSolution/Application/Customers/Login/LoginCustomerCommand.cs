using Application._Common.Commands;
using Application._Common.Security.Authorization;

namespace Application.Customers.Login;

[AllowAnonymous]
public record LoginCustomerCommand
    : ICommand<LoginCustomerCommandResponse>
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}