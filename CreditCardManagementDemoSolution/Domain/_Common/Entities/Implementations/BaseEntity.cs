using Domain._Common.Entities.Abstractions;

namespace Domain._Common.Entities.Implementations;

public abstract class BaseEntity : IEntity
{
    public Guid? Id { get; init; }
}
