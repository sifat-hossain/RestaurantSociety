namespace Spread.Connect.Identity.Extensions.Token;

public interface IAuthorizationTokenProvider
{
    (bool, IAuthorizationToken) TryGet();
}
