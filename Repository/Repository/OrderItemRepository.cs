using AutoMapper;
using Database;
using Database.Entites;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly XDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderItemRepository(XDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IOrderItem> GetByIdAsync(int id)
        {
            var entity = await _dbContext.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .FirstOrDefaultAsync(oi => oi.OrderItemId == id);

            return _mapper.Map<IOrderItem>(entity);
        }

        public async Task<IEnumerable<IOrderItem>> GetAllAsync()
        {
            var entities = await _dbContext.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .ToListAsync();

            return _mapper.Map<IEnumerable<IOrderItem>>(entities);
        }

        public async Task AddAsync(IOrderItem orderItem)
        {
            var entity = _mapper.Map<OrderItemDb>(orderItem);

            _dbContext.OrderItems.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(IOrderItem orderItem)
        {
            var entity = await _dbContext.OrderItems.FindAsync(orderItem.OrderItemId);

            if (entity == null)
            {
                throw new ArgumentException("Order item not found");
            }

            _mapper.Map(orderItem, entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(IOrderItem orderItem)
        {
            var entity = await _dbContext.OrderItems.FindAsync(orderItem.OrderItemId);

            if (entity == null)
            {
                throw new ArgumentException("Order item not found");
            }

            _dbContext.OrderItems.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
