using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Society.Identity.Extensions.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Restaurant.Society.Identity.Extensions;

public class JwtIdentityContext : IIdentityContext
{
    private readonly IAuthorizationTokenProvider _authorizationTokenProvider;
    private readonly IOptions<IdentityContextOptions> _options;

    public JwtIdentityContext(IAuthorizationTokenProvider authorizationTokenProvider,
        IOptions<IdentityContextOptions> options)
    {
        _authorizationTokenProvider = authorizationTokenProvider;
        _options = options;

        GetTokenClaims();
    }

    public Guid UserId { get; private set; }
    public Guid TenantId { get; private set; }
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string Surname { get; private set; }
    public string RefreshToken { get; private set; }
    public string AuthorizationHeader { get; private set; }
    public string AuthorizationScheme { get; private set; }
    public IEnumerable<string> Roles { get; private set; } = new List<string>();
    public IEnumerable<string> Customers { get; private set; } = new List<string>();

    private void GetTokenClaims()
    {
        (bool successful, IAuthorizationToken token) = _authorizationTokenProvider.TryGet();

        if (!successful)
        {
            return;
        }

        if (!(GetPrincipal(token) is ClaimsPrincipal principal))
        {
            return;
        }

        AuthorizationHeader = token.Value;
        AuthorizationScheme = token.Type;

        UserId = Guid.Parse(principal.FindFirstValue("user_id"));
        FirstName = principal.Identity.Name.ToString();
        Surname = principal.FindFirstValue("name");
        Email = principal.FindFirstValue("emailaddress");
        Roles = principal.Claims.Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();

        string tenantId = principal.FindFirstValue("user_id");

        if (tenantId is not null)
        {
            TenantId = Guid.Parse(tenantId);
        }
    }

    private IPrincipal GetPrincipal(IAuthorizationToken token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(token.Value);
            if (jwtSecurityToken == null)
            {
                return null;
            }

            var param = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SecurityKey))
            };

            return handler.ValidateToken(token.Value, param, out SecurityToken securityToken);
        }
        catch (Exception)
        {
            return null;
        }
    }
}
