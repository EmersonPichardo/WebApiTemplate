using Application._Common.Mapping;
using Domain._Security.Users;

namespace Application._Security.Users;

public record UserDto
    : IMapFrom<User>
{
    public required Guid Id { get; set; }
    public required string FullName { get; set; }
    public required UserStatus Status { get; set; }
}