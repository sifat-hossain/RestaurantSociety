﻿using Restaurant.Society.Domain.Framework.Attributes;

namespace Restaurant.Society.Application.Admin.Actions.Roles.Commands.CreateRole;

/// <summary>
/// Represents model for creating a role
/// </summary>
[SpreadRole(Constants.Roles.Admin)]
public class CreateRoleCommand : IRequest<RoleModel>
{
    /// <summary>
    /// Role name
    /// </summary>
    public string Name { get; set; }
}
