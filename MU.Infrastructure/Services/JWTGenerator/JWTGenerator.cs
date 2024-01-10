using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MU.Application.Services.JWTGenerator;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MU.Infrastructure.Services.JWTGenerator
{
    public class JWTGenerator : IJWTGenerator
    {
        private readonly JWTSettings _jwtSettings;

        public JWTGenerator(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(
            Guid id,
            string name,
            string address,
            DateTime birthay)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.UniqueName, name),
                new("address", address),
                new("birthayTicks", birthay.Ticks.ToString()),
                new("id", id.ToString()),
            };

            JwtSecurityToken token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}