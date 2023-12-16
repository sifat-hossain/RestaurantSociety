namespace Spread.Connect.Domain.Framework.Contracts.Email;

/// <summary>
/// Represents model for email sending
/// </summary>
public class EmailHelper
{
    /// <summary>Gets or sets the email.</summary>
    /// <value>The email.</value>
    public string Email { get; set; }

    /// <summary>Gets or sets the email body.</summary>
    public string Content { get; set; }

    /// <summary>
    /// Gets and sets the email subject
    /// </summary>
    public string? Subject { get; set; }

    /// <summary>Gets or sets the to email.</summary>
    /// <value>The cc email.</value>
    public string CcEmail { get; set; }

    /// <summary>Gets or sets the to email.</summary>
    /// <value>The bcc email.</value>
    public string BccEmail { get; set; }
}
