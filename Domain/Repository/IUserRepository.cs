using Domain.Entities;
using System.Security.Claims;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        public Task<IUser> GetByIdAsync(string id);
        public Task<IEnumerable<IUser>> GetAllAsync();
        public Task AddAsync(IUser user, string password);
        public Task UpdateAsync(IUser user);
        public Task RemoveAsync(IUser user);
        public Task<IUser> GetEmailAsync(string email);
        public Task<bool> CheckPasswordAsync(IUser user, string password);
        public Task<ClaimsIdentity> GetClaimsIdentityAsync(IUser user);
    }
}
