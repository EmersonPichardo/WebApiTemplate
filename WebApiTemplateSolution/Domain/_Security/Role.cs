using Domain._Common.Entities.Implementations;

namespace Domain._Security;

public class Role : BaseAuditableCompoundEntity
{
    public required string Name { get; set; }

    public IList<RolePermission> Permissions { get; set; } = [];
    public IList<UserRole> UsersRoles { get; set; } = [];
}
