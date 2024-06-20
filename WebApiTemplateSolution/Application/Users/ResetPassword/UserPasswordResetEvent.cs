namespace Application.Users.ResetPassword;

public record UserPasswordResetEvent
    : IEvent
{
    public required Guid UserId { get; init; }
    public required string EmployeeEmail { get; init; }
    public required string UserFullName { get; init; }
    public required string UserPassword { get; init; }
}
