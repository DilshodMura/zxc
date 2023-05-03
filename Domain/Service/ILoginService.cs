using Domain.Entities;

namespace Domain.Service
{
    public interface ILoginService
    {
        public Task<IJwtTokens> LoginAsync(string username, string password);
    }
}
