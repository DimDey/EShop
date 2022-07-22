using EShop.Domain.Core;
using EShop.Domain.Interfaces;
using EShop.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Data.Repository
{
    public class ProductCategoryRepository : IRepository<ProductCategory> {

        private readonly EShopContext _dbContext;

        public ProductCategoryRepository(EShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            return await _dbContext.ProductCategories.ToListAsync();
        }

        public async Task Add(ProductCategory entity)
        {
            _dbContext.ProductCategories.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(ProductCategory entity)
        {
            _dbContext.ProductCategories.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductCategory?> Get(int id)
        {
            return await _dbContext.ProductCategories
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(ProductCategory entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        
        public IEnumerable<ProductCategory> Get(Func<ProductCategory, bool> predicate)
        {
            return _dbContext.ProductCategories.Where(predicate).ToList();
        }
    }
}
