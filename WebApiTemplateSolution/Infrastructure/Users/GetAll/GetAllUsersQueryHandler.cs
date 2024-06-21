using Application._Common.Persistence.Databases;
using Application.Users.GetAll;
using AutoMapper;
using Domain.Security;
using Infrastructure._Common.GenericHandlers;

namespace Infrastructure.Users.GetAll;

internal class GetAllUsersQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    : GetAllEntitiesQueryHandler<GetUsersQuery, GetUsersQueryResponse, User>(dbContext, mapper)
    , IGetAllUsersQueryHandler;
