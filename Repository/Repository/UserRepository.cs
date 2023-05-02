using AutoMapper;
using Database;
using Database.Entites;
using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly XDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUserDb> _userManager;

        public UserRepository(XDbContext dbContext, IMapper mapper, UserManager<ApplicationUserDb> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IUser> GetByIdAsync(string id)
        {
            var userEntity = await _userManager.FindByIdAsync(id);
            return _mapper.Map<IUser>(userEntity);
        }

        public async Task<IEnumerable<IUser>> GetAllAsync()
        {
            var userEntities = await _dbContext.ApplicationUsers.ToListAsync();
            return _mapper.Map<IEnumerable<IUser>>(userEntities);
        }

        public async Task AddAsync(IUser user, string password)
        {
            var userEntity = _mapper.Map<ApplicationUserDb>(user);

            if (userEntity.Role == "Admin" || userEntity.Role == "Customer")
            {
                var result = await _userManager.CreateAsync(userEntity, password);
                if (!result.Succeeded)
                {
                    var errors = string.Join(Environment.NewLine, result.Errors.Select(e => e.Description));
                    throw new ApplicationException($"Could not create user: {errors}");
                }
            }
            else
            {
                throw new ApplicationException($"Invalid user role: {userEntity.Role}");
            }
        }

        public async Task UpdateAsync(IUser user)
        {
            var userEntity = await _userManager.FindByIdAsync(user.Id);
            if (userEntity == null)
            {
                throw new ApplicationException($"User not found: {user.Id}");
            }

            if (userEntity.Role == "Admin" || userEntity.Role == "Customer")
            {
                _mapper.Map(user, userEntity);
                var result = await _userManager.UpdateAsync(userEntity);
                if (!result.Succeeded)
                {
                    var errors = string.Join(Environment.NewLine, result.Errors.Select(e => e.Description));
                    throw new ApplicationException($"Could not update user: {errors}");
                }
            }
            else
            {
                throw new ApplicationException($"Invalid user role: {userEntity.Role}");
            }
        }

        public async Task RemoveAsync(IUser user)
        {
            var userEntity = await _userManager.FindByIdAsync(user.Id);
            if (userEntity == null)
            {
                throw new ApplicationException($"User not found: {user.Id}");
            }

            if (userEntity.Role == "Admin" || userEntity.Role == "Customer")
            {
                var result = await _userManager.DeleteAsync(userEntity);
                if (!result.Succeeded)
                {
                    var errors = string.Join(Environment.NewLine, result.Errors.Select(e => e.Description));
                    throw new ApplicationException($"Could not delete user: {errors}");
                }
            }
            else
            {
                throw new ApplicationException($"Invalid user role: {userEntity.Role}");
            }
        }
    }
}
