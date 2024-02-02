using Application._Common.Persistence.Databases;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure._Common.Persistence.Databases.ApplicationDbContext.Configurations;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Customer>
{
    internal static readonly int EmailLength = 64;

    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .ToTable(nameof(IApplicationDbContext.Customers))
            .ConfigureKeys()
            .ConfigureDeletionFilter();

        builder.HasIndex(entity => entity.UserId).ConfigureUniqueness();
        builder.HasIndex(entity => entity.Email).ConfigureUniqueness();

        builder.Property(entity => entity.Email).HasMaxLength(EmailLength);
    }
}
