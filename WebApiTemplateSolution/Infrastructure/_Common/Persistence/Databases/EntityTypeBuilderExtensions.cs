﻿using Domain._Common.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure._Common.Persistence.Databases;

internal static class EntityTypeBuilderExtensions
{
    internal const string UniquenessFilter = $"{nameof(IAuditableEntity.IsDeleted)} = 'FALSE'";

    internal static EntityTypeBuilder<TEntity> ConfigureKeys<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, ICompoundEntity
    {
        builder.HasKey(entity => entity.Id);
        builder.HasIndex(entity => entity.ClusterId);

        builder.Property(entity => entity.Id).HasDefaultValueSql("NEWID()").IsRequired();
        builder.Property(entity => entity.ClusterId).ValueGeneratedOnAdd().IsRequired().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        return builder;
    }

    internal static EntityTypeBuilder<TEntity> ConfigureDeletionFilter<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IAuditableEntity
    {
        builder.Property(entity => entity.IsDeleted).HasDefaultValue(false);
        builder.HasQueryFilter(entity => !entity.IsDeleted);

        return builder;
    }

    internal static IndexBuilder<TProperty> ConfigureUniqueness<TProperty>(this IndexBuilder<TProperty> builder)
    {
        builder.IsUnique().HasFilter(UniquenessFilter);

        return builder;
    }
}
