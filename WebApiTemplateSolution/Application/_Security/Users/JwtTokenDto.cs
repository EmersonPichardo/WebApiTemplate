namespace Application._Security.Users;

public record JwtTokenDto
{
    public required DateTime Expires { get; init; }
    public required string Value { get; init; }
}