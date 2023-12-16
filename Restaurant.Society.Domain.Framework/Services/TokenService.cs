using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Society.Domain.Digital.Menu;
using Restaurant.Society.Domain.Framework.Interfaces;
using Restaurant.Society.Domain.Framework.Settings;
using Spread.Connect.Domain.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restaurant.Society.Domain.Framework.Services
{
    /// <summary>
    /// ITokenService implementation
    /// </summary>
    public class TokenService : ITokenService
    {
        /// <summary>
        /// The authentication settings
        /// </summary>
        private readonly AuthSettings _authSettings;
        /// <summary>The random generator</summary>
        private readonly Random _random;

        /// <summary>The alphanumeric chars</summary>
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public TokenService(IOptions<AuthSettings> authSettings)
        {
            _authSettings = authSettings.Value;
            _random = new Random();
        }

        /// <summary>
        /// Generates new JWT token for the user
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>new JWT token</returns>
        public string GenerateToken(ISpreadTokanable user)
        {
            string guid = Guid.NewGuid().ToString();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, guid),
                new Claim(JwtClaimTypes.USER_ID, user.UserId.ToString()),
                new Claim(JwtClaimTypes.REQUIRES_PASSWORD_RESET, user.RequiresPasswordReset.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),

                //new Claim(JwtClaimTypes.TENANT_ID, user.TenantId.ToString()),
                //new Claim(JwtClaimTypes.EMPLOYER_NAME, user.EmployerName),
                //new Claim(JwtClaimTypes.LOG_LEVEL, user.LogLevel.ToString()),
               
                //new Claim(ClaimTypes.GivenName, user.FirstName),
                //new Claim(ClaimTypes.Surname, user.Surname),
              
            };

            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role)));

            //foreach ((string permissionName, string tenantId) in user.TenantPermission)
            //{
            //    claims.Add(new Claim(JwtClaimTypes.PERMISSION,
            //        JsonConvert.SerializeObject(
            //            new
            //            {
            //                tenantId,
            //                permissionName
            //            }
            //        )));
            //}

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.SigningKey));

            var jwt = new JwtSecurityToken(
                issuer: _authSettings.Issuer,
                audience: _authSettings.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_authSettings.LifetimeMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return accessToken;
        }

        /// <summary>
        /// Generates a new JWT token for a merlin user
        /// </summary>
        /// <param name="user">Merlin user</param>
        /// <returns>New JWT token</returns>
        public string GenerateMerlinToken(ITokenable user)
        {
            string guid = Guid.NewGuid().ToString();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, guid),
                new Claim(JwtClaimTypes.USER_ID, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                //new Claim(ClaimTypes.GivenName, user.FirstName),
                //new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, Constants.Roles.Admin)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.SigningKey));

            var jwt = new JwtSecurityToken(
                issuer: _authSettings.Issuer,
                audience: _authSettings.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_authSettings.LifetimeMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return accessToken;
        }

        /// <summary>
        /// Generates a new refresh token for the user
        /// </summary>
        /// <returns></returns>
        public string GenerateRefreshToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            return Convert.ToBase64String(time.Concat(key).ToArray());
        }

        /// <summary>Generates the temporary password.</summary>
        /// <returns>The temporary password</returns>
        public string GenerateTempPassword()
        {
            return new string(Enumerable.Range(1, 6)
                .Select(_ => Chars[_random.Next(Chars.Length)]).ToArray());
        }
    }
}
