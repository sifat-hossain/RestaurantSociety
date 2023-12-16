namespace Spread.Connect.Application.Admin.Actions.Users.Query.UserList;

/// <summary>
/// Represents model for user list
/// </summary>
//[SpreadRole(Constants.Roles.Admin)]
public class UserListQuery : IRequest<List<UserModel>>
{
    public int? Skip { get; set; }
    public int? Take { get; set; }
}
