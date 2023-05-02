using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.DTO_models;

namespace Services.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public IJwtTokens GenerateTokens(ClaimsIdentity identity)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["JwtConfig:AccessTokenLifetimeMinutes"]));
            var refreshExpiry = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["JwtConfig:RefreshTokenLifetimeMinutes"]));

            var accessToken = new JwtSecurityToken(
                _config["JwtConfig:Issuer"],
                _config["JwtConfig:Audience"],
                identity.Claims,
                expires: expiry,
                signingCredentials: credentials
            );

            var refreshToken = new JwtSecurityToken(
                _config["JwtConfig:Issuer"],
                _config["JwtConfig:Audience"],
                new[] { new Claim("jti", Guid.NewGuid().ToString()) },
                expires: refreshExpiry,
                signingCredentials: credentials
            );

            return new JwtTokensDTO
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken)
            };
        }

        public ClaimsPrincipal ValidateAccessToken(string token)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _config["JwtConfig:Issuer"],
                ValidAudience = _config["JwtConfig:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:SecretKey"]))
            };

            var handler = new JwtSecurityTokenHandler();
            try
            {
                var principal = handler.ValidateToken(token, validationParameters, out var validatedToken);
                if (!(validatedToken is JwtSecurityToken jwtSecurityToken) ||
                    !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new SecurityTokenException("Invalid token");
                }
                return principal;
            }
            catch (Exception ex)
            {
                // Log exception
                return null;
            }
        }
    }
}
