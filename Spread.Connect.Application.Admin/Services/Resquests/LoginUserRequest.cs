namespace Spread.Connect.Application.Admin.Services.Resquests;

/// <summary>
/// Represents model for logging in
/// </summary>
public class LoginUserRequest
{
    /// <summary>
    /// Users username
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Users password
    /// </summary>
    public string Password { get; set; }
}
