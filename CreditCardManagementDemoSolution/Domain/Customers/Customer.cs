using Domain._Common.Entities.Implementations;
using Domain._Security.Users;

namespace Domain.Customers;

public class Customer : BaseAuditableCompoundEntity
{
    public required Guid UserId { get; set; }
    public required string Email { get; set; }

    public User? User { get; set; }
}