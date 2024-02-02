using Application._Common.Persistence.Databases;
using Domain._Security.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure._Common.Persistence.Databases.ApplicationDbContext.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    internal static readonly int PasswordLength = 128;
    internal static readonly int SaltLength = 32;
    internal static readonly int FullNameLength = 64;

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable(nameof(IApplicationDbContext.Users))
            .ConfigureKeys()
            .ConfigureDeletionFilter();

        builder.Property(entity => entity.Password).HasMaxLength(PasswordLength);
        builder.Property(entity => entity.Salt).HasMaxLength(SaltLength);
        builder.Property(entity => entity.FullName).HasMaxLength(FullNameLength);
        builder.Property(entity => entity.Status).HasColumnType("varchar(50)").HasConversion(
            valueTo => valueTo.ToString(),
            valueFrom => Enum.Parse<UserStatus>(valueFrom)
        );
    }
}
