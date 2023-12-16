using Restaurant.Society.Domain.Framework.Attributes;

namespace Restaurant.Society.Application.Admin.Actions.Roles.Query.RoleList;

/// <summary>
/// Represents model for role list
/// </summary>
[SpreadRole(Constants.Roles.Admin)]
public class RoleListQuery : IRequest<List<RoleModel>>
{
}
