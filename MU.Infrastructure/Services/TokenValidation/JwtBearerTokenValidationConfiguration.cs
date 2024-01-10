using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MU.Infrastructure.Services.JWTGenerator;
using System.Text;

namespace MU.Infrastructure.Services.TokenValidation
{
    public sealed class JwtBearerTokenValidationConfiguration : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JWTSettings _jwtSettings;
        public JwtBearerTokenValidationConfiguration(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public void Configure(string? name, JwtBearerOptions options) => Configure(options);

        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            };
        }
    }
}
