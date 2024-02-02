using Application._Security.Users;
using Application.Customers.RefreshToken;

namespace Application.Customers.Login;

public record LoginCustomerCommandResponse
    : RefreshCustomerTokenCommandResponse
{
    public required JwtTokenDto RefreshToken { get; init; }
}