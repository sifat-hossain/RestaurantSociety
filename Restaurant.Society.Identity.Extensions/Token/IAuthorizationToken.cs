namespace Restaurant.Society.Identity.Extensions.Token;

public interface IAuthorizationToken
{
    string Type { get; }
    string Value { get; }

    string ToString();
}
