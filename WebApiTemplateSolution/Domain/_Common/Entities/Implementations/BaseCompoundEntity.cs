using Domain._Common.Entities.Abstractions;

namespace Domain._Common.Entities.Implementations;

public abstract class BaseCompoundEntity
    : BaseEntity, ICompoundEntity
{
    public int ClusterId { get; init; }
}