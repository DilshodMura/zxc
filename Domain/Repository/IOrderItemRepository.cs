using Domain.Entities;

namespace Domain.Repository
{
    public interface IOrderItemRepository
    {
        public Task<IOrderItem> GetByIdAsync(int id);
        public Task<IEnumerable<IOrderItem>> GetAllAsync();
        public Task AddAsync(IOrderItem orderItem);
        public Task UpdateAsync(IOrderItem orderItem);
        public Task RemoveAsync(IOrderItem orderItem);
    }
}
