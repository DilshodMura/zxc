using Domain.Entities;

namespace Domain.Repository
{
    public interface IOrderRepository
    {
        public Task<IOrder> GetByIdAsync(int id);
        public Task<IEnumerable<IOrder>> GetAllAsync();
        public Task AddAsync(IOrder order);
        public Task UpdateAsync(IOrder order);
        public Task RemoveAsync(IOrder order);
        public Task<IEnumerable<IOrder>> GetOrdersByCustomerIdAsync(int customerId);
    }
}
