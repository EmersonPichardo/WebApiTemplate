using MediatR;

namespace Application.Roles.GetAll;

public interface IGetAllRolesQueryHandler
    : IRequestHandler<GetRolesQuery, IList<GetRolesQueryResponse>>;
