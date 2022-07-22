using EShop.Domain.Core;
using EShop.Domain.Interfaces;
using EShop.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Data.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly EShopContext _dbContext;

        public UserRepository(EShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task Add(User entity)
        {
            _dbContext.Users.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(User entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> Get(int id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            return _dbContext.Users.Where(predicate);
        }
    }
}

