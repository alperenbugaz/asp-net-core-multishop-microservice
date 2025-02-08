using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiShop.IdentityServer.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            var claims = new List<Claim>();
            if(!string.IsNullOrEmpty(model.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role,model.Role ));
            }
            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));
            if (!string.IsNullOrEmpty(model.UserName))
            {
                claims.Add(new Claim("Username", model.UserName));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
            var token = new JwtSecurityToken(
                issuer:JwtTokenDefaults.ValidIssuer,
                audience:JwtTokenDefaults.ValidAudience,
                claims:claims,
                expires: expires,
                signingCredentials: creds
            );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(handler.WriteToken(token), expires);
        }
    }
}
