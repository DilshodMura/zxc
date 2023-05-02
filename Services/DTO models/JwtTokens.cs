using Domain.Entities;

namespace Services.DTO_models
{
    public sealed class JwtTokens:IJwtTokens
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
