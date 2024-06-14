using Domain._Common.Entities.Implementations;
using Domain._Common.Modularity;

namespace Domain._Security;

public class RolePermission : BaseAuditableCompoundEntity
{
    public Guid RoleId { get; set; }
    public required Component Component { get; set; }
    public required int RequiredAccess { get; set; }

    public Role? Role { get; set; }
}
