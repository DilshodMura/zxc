using Domain.Entities;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        public Task<IUser> GetByIdAsync(string id);
        public Task<IEnumerable<IUser>> GetAllAsync();
        public Task AddAsync(IUser user, string password);
        public Task UpdateAsync(IUser user);
        public Task RemoveAsync(IUser user);
    }
}
