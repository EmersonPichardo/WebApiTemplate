using MediatR;

namespace Application.Users.GetAll;

public interface IGetAllUsersQueryHandler
    : IRequestHandler<GetUsersQuery, IList<GetUsersQueryResponse>>;
