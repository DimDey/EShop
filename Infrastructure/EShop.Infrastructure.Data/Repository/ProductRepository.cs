using System.Linq.Expressions;
using EShop.Domain.Core;
using EShop.Domain.Interfaces;
using EShop.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Data.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly EShopContext _dbContext;

        public ProductRepository(EShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        } 

        public async Task Add(Product entity)
        {
            _dbContext.Products.Add(entity);
           await  _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Product entity)
        {
            _dbContext.Products.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Product entity)
        {
            _dbContext.Products.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product?> Get(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(e => e.Id == id);
        }
        
        public async Task<Product?> Get(Expression<Func<Product, bool>> predicate)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(predicate);
        }
    }
}
