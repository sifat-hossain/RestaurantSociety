namespace Spread.Connect.Application.Admin.Actions.Emails.Commands;

/// <summary>
/// Represents model for Email sending
/// </summary>
public class EmailSenderCommand : IRequest
{
    /// <summary>
    /// Email send from
    /// </summary>
    public string From { get; set; }

    /// <summary>
    /// Email send to
    /// </summary>
    public string To { get; set; }

    /// <summary>
    /// Email cc
    /// </summary>
    public string? Cc { get; set; }

    /// <summary>
    /// Email cc
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Email body
    /// </summary>
    public string? Body { get; set; }

}
