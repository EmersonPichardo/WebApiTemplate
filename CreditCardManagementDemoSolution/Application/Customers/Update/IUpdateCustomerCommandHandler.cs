using MediatR;

namespace Application.Customers.Update;

public interface IUpdateCustomerCommandHandler
    : IRequestHandler<UpdateCustomerCommand>
{ }