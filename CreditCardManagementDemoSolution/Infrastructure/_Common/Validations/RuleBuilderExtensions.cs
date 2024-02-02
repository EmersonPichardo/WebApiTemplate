using Domain._Common.Entities.Abstractions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure._Common.Validations;

internal static class RuleBuilderExtensions
{
    internal static IRuleBuilderOptions<TModel, TProperty> ExistAsync<TModel, TProperty, TEntity>(
        this IRuleBuilder<TModel, TProperty> ruleBuilder,
        DbSet<TEntity> entities,
        Expression<Func<TEntity, TProperty>> selector
    )
        where TEntity : class, IEntity
        where TProperty : IEquatable<TProperty>
    {
        return ruleBuilder
            .MustAsync(
                async (property, cancellationToken)
                    => await ExistInSet(entities, selector, property, cancellationToken)
            );
    }

    internal static IRuleBuilderOptions<TModel, TProperty> NotExistAsync<TModel, TProperty, TEntity>(
        this IRuleBuilder<TModel, TProperty> ruleBuilder,
        DbSet<TEntity> entities,
        Expression<Func<TEntity, TProperty>> selector
    )
        where TEntity : class, IEntity
        where TProperty : IEquatable<TProperty>
    {
        return ruleBuilder
            .MustAsync(
                async (property, cancellationToken)
                    => await NotExistInSet(entities, selector, property, cancellationToken)
            );
    }

    private static async Task<bool> ExistInSet<TProperty, TEntity>(
        DbSet<TEntity> entities,
        Expression<Func<TEntity, TProperty>> selector,
        TProperty property,
        CancellationToken cancellationToken = default
    )
        where TProperty : IEquatable<TProperty>
        where TEntity : class, IEntity
    {
        return await entities
            .AsNoTracking()
            .Select(selector)
            .AnyAsync(
                entityProperty => entityProperty.Equals(property),
                cancellationToken
            );
    }
    private static async Task<bool> NotExistInSet<TProperty, TEntity>(
        DbSet<TEntity> entities,
        Expression<Func<TEntity, TProperty>> selector,
        TProperty property,
        CancellationToken cancellationToken
    )
        where TProperty : IEquatable<TProperty>
        where TEntity : class, IEntity
    {
        return !await ExistInSet(entities, selector, property, cancellationToken);
    }
}

