﻿using Domain._Common.Entities.Implementations;

namespace Domain._Security.Users;

public class User : BaseAuditableCompoundEntity
{
    public required string FullName { get; set; }
    public required string Password { get; set; }
    public required string Salt { get; set; }
    public required UserStatus Status { get; set; }
}

public enum UserStatus
{
    Inactive = 0,
    Active = 1,
    RequiredPasswordChange = 2
}