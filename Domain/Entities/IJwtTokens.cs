
namespace Domain.Entities
{
    public interface IJwtTokens
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
