using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Newtonsoft.Json;
using CRM.Models.View;

namespace CRM.Common.Helpers
{
    public static class TokenHelper
    {
        public static readonly JwtSettings _jwtSettings;
        private static readonly double _expirs = 24;
        static TokenHelper()
        {
            _jwtSettings = ConfigurationHelper.GetInstance().GetSection("JwtSettings").Get<JwtSettings>();
        }

        public static string GenerateToken(JwtUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey.ToMD5String());
            var tokenDescriper = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim("AccountId", user.Id),
                    new Claim("Name", user.Name),
                    new Claim("Role", user.RolesString),
                    new Claim("Account", user.Account)
                }),
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationHours == null ? _expirs : Convert.ToDouble(_jwtSettings.ExpirationHours)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriper);
            return tokenHandler.WriteToken(token);
        }

        public static AccountData VerifyToken(string token)
        {
            SecurityKey key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.SecretKey.ToMD5String()));
            var jwtTokenInfo = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var result = new AccountData()
            {
                Account = jwtTokenInfo.Claims.FirstOrDefault(a => a.Type == "Account").Value,
                AccountId = Convert.ToUInt64(jwtTokenInfo.Claims.FirstOrDefault(a => a.Type == "AccountId").Value),
                RoleString = jwtTokenInfo.Claims.FirstOrDefault(a=> a.Type == "Role").Value,
                Name = jwtTokenInfo.Claims.FirstOrDefault(a=> a.Type == "Name").Value
            };

            return result;
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
