using AutoMapper;
using Database;
using Database.Entites;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly XDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerRepository(XDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ICustomer> GetByIdAsync(int id)
        {
            var customerEntity = await _dbContext.Customers.FindAsync(id);
            return _mapper.Map<Customer>(customerEntity);
        }

        public async Task<IEnumerable<ICustomer>> GetAllAsync()
        {
            var customerEntities = await _dbContext.Customers.ToListAsync();
            return _mapper.Map<IEnumerable<Customer>>(customerEntities);
        }

        public async Task AddAsync(ICustomer customer)
        {
            var customerEntity = _mapper.Map<CustomerEntity>(customer);
            await _dbContext.Customers.AddAsync(customerEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ICustomer customer)
        {
            var customerEntity = _mapper.Map<CustomerEntity>(customer);
            _dbContext.Entry(customerEntity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(ICustomer customer)
        {
            var customerEntity = _mapper.Map<CustomerEntity>(customer);
            _dbContext.Customers.Remove(customerEntity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
