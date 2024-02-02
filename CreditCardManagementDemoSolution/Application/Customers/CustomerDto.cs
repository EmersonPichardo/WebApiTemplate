using Application._Common.Mapping;
using Application._Security.Users;
using Domain.Customers;

namespace Application.Customers;

public record CustomerDto
    : IMapFrom<Customer>
{
    public required Guid Id { get; set; }
    public required string Email { get; set; }

    public required UserDto User { get; set; }
}