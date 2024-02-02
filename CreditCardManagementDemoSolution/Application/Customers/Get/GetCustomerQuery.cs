using Application._Common.Caching;
using Application._Common.Queries;
using Domain._Common.Enums;

namespace Application.Customers.Get;

[Cache(AppModule.Customers)]
public record GetCustomerQuery
    : GetEntityQuery<GetCustomerQueryResponse>;