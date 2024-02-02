using Domain._Common.Entities.Abstractions;

namespace Domain._Common.Entities.Implementations;

public abstract class BaseAuditableCompoundEntity
    : BaseCompoundEntity, IAuditableEntity
{
    public DateTime CreationDate { get; set; }
    public Guid? CreatedBy { get; set; }

    public DateTime LastModificationDate { get; set; }
    public Guid? LastModifiedBy { get; set; }

    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletionDate { get; set; }
    public Guid? DeletedBy { get; set; }
}