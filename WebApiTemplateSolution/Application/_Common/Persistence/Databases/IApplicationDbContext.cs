using Domain._Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application._Common.Persistence.Databases;

public interface IApplicationDbContext
{
    //dbo
    public DbSet<User> Users => Set<User>();

    //base
    public DatabaseFacade Database { get; }

    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
