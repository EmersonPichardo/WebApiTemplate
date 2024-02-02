using MediatR;

namespace Application.Customers.Add;

public interface IAddCustomerCommandHandler
    : IRequestHandler<AddCustomerCommand>
{ }