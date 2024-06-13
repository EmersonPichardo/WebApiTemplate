namespace Application._Security.Users.ResetPassword;

public record UserPasswordResetEvent
    : UserChangedEvent
{
    public required string EmployeeEmail { get; init; }
    public required string UserFullName { get; init; }
    public required string UserPassword { get; init; }
}
