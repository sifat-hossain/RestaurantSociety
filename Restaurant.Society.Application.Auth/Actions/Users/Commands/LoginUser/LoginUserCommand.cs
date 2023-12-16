using Restaurant.Society.Domain.Framework.Attributes;

namespace Restaurant.Society.Application.Auth.Actions.Users.Commands.LoginUser;

/// <summary>
/// Represents model for logging in
/// </summary>
public class LoginUserCommand : IRequest<UserTokenModel>
{
    /// <summary>
    /// Users username
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Users password
    /// </summary>
    [SensitiveData]
    public string Password { get; set; }
}
