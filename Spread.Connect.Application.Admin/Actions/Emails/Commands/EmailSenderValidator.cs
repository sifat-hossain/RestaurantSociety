namespace Spread.Connect.Application.Admin.Actions.Emails.Commands;

public class EmailSenderValidator : AbstractValidator<EmailSenderCommand>
{
    public EmailSenderValidator()
    {
        RuleFor(r => r.To)
            .NotEmpty();

        RuleFor(r => r.From)
            .NotEmpty();
    }
}
