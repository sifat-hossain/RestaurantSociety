﻿namespace Spread.Connect.Application.Admin.Actions.Roles.Commands.DeleteRole;

/// <summary>
/// Represents model for deleting a role
/// </summary>
[SpreadRole(Constants.Roles.Admin)]
public class DeleteRoleCommand : IRequest
{
    /// <summary>
    /// Role unique identifier
    /// </summary>
    public Guid RoleId { get; set; }
}
