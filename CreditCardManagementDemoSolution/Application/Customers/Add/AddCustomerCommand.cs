using Application._Common.Caching;
using Application._Common.Commands;
using Application._Common.Security.Authorization;
using Domain._Common.Enums;

namespace Application.Customers.Add;

[AllowAnonymous, Cache(AppModule.Customers)]
public record AddCustomerCommand
    : ICommand
{
    public required string FullName { get; init; }
    public required string Email { get; init; }
}