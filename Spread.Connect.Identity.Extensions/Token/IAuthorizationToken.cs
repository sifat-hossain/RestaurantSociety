namespace Spread.Connect.Identity.Extensions.Token;

public interface IAuthorizationToken
{
    string Type { get; }
    string Value { get; }

    string ToString();
}
