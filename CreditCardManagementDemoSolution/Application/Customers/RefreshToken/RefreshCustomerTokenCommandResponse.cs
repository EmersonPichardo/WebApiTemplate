using Application._Security.Users;
using Domain._Security.Users;

namespace Application.Customers.RefreshToken;

public record RefreshCustomerTokenCommandResponse
{
    public required string FullName { get; init; }
    public required UserStatus UserStatus { get; init; }
    public required JwtTokenDto Token { get; init; }
}