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
        
        public IEnumerable<Product> Get(Func<Product, bool> predicate)
        {
            return _dbContext.Products.Where(predicate).ToList();
        }
    }
}
