using AutoMapper;
using Database;
using Database.Entites;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly XDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(XDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IOrder> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            return _mapper.Map<IOrder>(entity);
        }

        public async Task<IEnumerable<IOrder>> GetAllAsync()
        {
            var entities = await _dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ToListAsync();

            return _mapper.Map<IEnumerable<IOrder>>(entities);
        }

        public async Task AddAsync(IOrder order)
        {
            var entity = _mapper.Map<OrderDb>(order);

            _dbContext.Orders.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(IOrder order)
        {
            var entity = await _dbContext.Orders.FindAsync(order.Id);

            if (entity == null)
            {
                throw new ArgumentException("Order not found");
            }

            _mapper.Map(order, entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(IOrder order)
        {
            var entity = await _dbContext.Orders.FindAsync(order.OrderId);

            if (entity == null)
            {
                throw new ArgumentException("Order not found");
            }

            _dbContext.Orders.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<IOrder>> GetOrdersByCustomerIdAsync(int customerId)
        {
            var entities = await _dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<IOrder>>(entities);
        }
    }
}
