using Domain.Entities;

namespace Domain.Service
{
    public interface IUserService
    {
        Task<IUser> RegisterUser(IUser user);
        Task<IJwtTokens> Login(ILoginDTO loginDto);
        Task<IUser> GetUserById(string userId);
    }

}
