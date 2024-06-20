using Domain.Security;

namespace Application.Users;

public record UserDto : IMapFrom<User>
{
    public required Guid Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required UserStatus Status { get; set; }
}