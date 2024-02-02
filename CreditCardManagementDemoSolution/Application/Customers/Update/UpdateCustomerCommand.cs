using Application._Common.Caching;
using Application.Customers.Add;
using Domain._Common.Enums;

namespace Application.Customers.Update;

[Cache(AppModule.Customers)]
public record UpdateCustomerCommand
    : AddCustomerCommand
{
    public required Guid Id { get; init; }
}