
using System.Security.Claims;

namespace Domain.JWT
{
    public interface IJwtService
    {
        public string GenerateAccessToken(ClaimsIdentity identity);
        public string GenerateRefreshToken();
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
