﻿using Domain._Common.Entities.Implementations;

namespace Domain._Security;

public class UserRole : BaseAuditableCompoundEntity
{
    public required Guid UserId { get; set; }
    public required Guid RoleId { get; set; }

    public User? User { get; set; }
    public Role? Role { get; set; }
}
