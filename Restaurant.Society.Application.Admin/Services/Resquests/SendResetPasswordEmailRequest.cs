namespace Restaurant.Society.Application.Admin.Services.Resquests;

/// <summary>
/// Represents request for sending reset password email request
/// </summary>
public class SendResetPasswordEmailRequest
{
    /// <summary>Gets or sets the email.</summary>
    /// <value>The email.</value>
    public string Email { get; set; }

    /// <summary>Gets or sets the temporary password.</summary>
    /// <value>The temporary password.</value>
    public string TempPassword { get; set; }
}
