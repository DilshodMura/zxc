using Domain.Entities;

namespace Domain.Repository
{
    public interface ICustomerRepository
    {
        Task<ICustomer> GetByIdAsync(int id);
        Task<IEnumerable<ICustomer>> GetAllAsync();
        Task AddAsync(ICustomer customer);
        Task UpdateAsync(ICustomer customer);
        Task RemoveAsync(ICustomer customer);
    }
}
