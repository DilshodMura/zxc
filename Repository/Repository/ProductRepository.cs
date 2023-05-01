using AutoMapper;
using Database;
using Database.Entites;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly XDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(XDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IProduct> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Products.FindAsync(id);

            return _mapper.Map<IProduct>(entity);
        }

        public async Task<IEnumerable<IProduct>> GetAllAsync()
        {
            var entities = await _dbContext.Products.ToListAsync();

            return _mapper.Map<IEnumerable<IProduct>>(entities);
        }

        public async Task AddAsync(IProduct product)
        {
            var entity = _mapper.Map<ProductDb>(product);

            _dbContext.Products.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(IProduct product)
        {
            var entity = await _dbContext.Products.FindAsync(product.ProductId);

            if (entity == null)
            {
                throw new ArgumentException("Product not found");
            }

            _mapper.Map(product, entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(IProduct product)
        {
            var entity = await _dbContext.Products.FindAsync(product.ProductId);

            if (entity == null)
            {
                throw new ArgumentException("Product not found");
            }

            _dbContext.Products.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
