using Domain.Entities;

namespace Domain.Repository
{
    public interface IProductRepository
    {
        public Task<IProduct> GetByIdAsync(int id);
        public Task<IEnumerable<IProduct>> GetAllAsync();
        public Task AddAsync(IProduct product);
        public Task UpdateAsync(IProduct product);
        public Task RemoveAsync(IProduct product);
    }
}
