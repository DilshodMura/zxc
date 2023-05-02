using Domain.Entities;
using System.Security.Claims;

namespace Domain.Service
{
    public interface IJwtService
    {
        public IJwtTokens GenerateTokens(ClaimsIdentity identity);
        public ClaimsPrincipal ValidateAccessToken(string token);
    }
}
