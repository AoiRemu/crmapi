using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Newtonsoft.Json;

namespace CRM.Common.Helpers
{
    public class TokenHelper
    {
        public readonly JwtSettings _jwtSettings;
        private readonly double _expirs = 24;
        public TokenHelper(IConfiguration configuration)
        {
            _jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
        }

        public string GenerateToken(JwtUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey.ToMD5String());
            var tokenDescriper = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.RolesString),
                    new Claim("Account", user.Account)
                }),
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationHours == null ? _expirs : Convert.ToDouble(_jwtSettings.ExpirationHours)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriper);
            return tokenHandler.WriteToken(token);
        }
    }

    public class JwtSettings
    {
        public string? SecretKey { get; set; }

        public string? ExpirationHours { get; set; }
    }

    public class JwtUser
    {
        public string? Account { get; set; }

        public string? Name { get; set; }

        public string? Id { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public string RolesString => string.Join(",", this.Roles);
    }
}
