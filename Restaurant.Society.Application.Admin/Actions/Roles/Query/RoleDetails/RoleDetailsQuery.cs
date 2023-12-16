﻿using Restaurant.Society.Domain.Framework.Attributes;

namespace Restaurant.Society.Application.Admin.Actions.Roles.Query.RoleDetails;

/// <summary>
/// Represents model for role details
/// </summary>
[SpreadRole(Constants.Roles.Admin)]
public class RoleDetailsQuery : IRequest<RoleModel>
{
    public Guid RoleId { get; set; }
}
