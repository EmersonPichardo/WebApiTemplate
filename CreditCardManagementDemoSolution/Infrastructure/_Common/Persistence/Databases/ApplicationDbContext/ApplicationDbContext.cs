using Application._Common.Persistence.Databases;
using Infrastructure._Common.Persistence.Databases.Interceptors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure._Common.Persistence.Databases.ApplicationDbContext;

internal class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options,
    AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor
)
    : DbContext(options)
    , IApplicationDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly())
            .MapToNormalizeMethod();

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .AddInterceptors(auditableEntitySaveChangesInterceptor)
            .UseEnumCheckConstraints();
}
