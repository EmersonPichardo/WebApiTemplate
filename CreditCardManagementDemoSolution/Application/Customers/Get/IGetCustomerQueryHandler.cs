using MediatR;

namespace Application.Customers.Get;

public interface IGetCustomerQueryHandler
    : IRequestHandler<GetCustomerQuery, GetCustomerQueryResponse>
{ }