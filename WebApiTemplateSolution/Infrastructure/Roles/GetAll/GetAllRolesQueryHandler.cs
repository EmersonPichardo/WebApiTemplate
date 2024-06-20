using Application._Common.Persistence.Databases;
using Application.Roles.GetAll;
using AutoMapper;
using Domain.Security;
using Infrastructure._Common.GenericHandlers;

namespace Infrastructure.Roles.GetAll;

internal class GetAllRolesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    : GetAllEntitiesQueryHandler<GetRolesQuery, GetRolesQueryResponse, Role>(dbContext, mapper)
    , IGetAllRolesQueryHandler;
