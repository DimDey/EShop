using EShop.Infrastructure.Context;
using EShop.Infrastructure.Models;
using EShop.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Repository
{
    public class ProductCategoryRepository : IRepository<ProductCategory> {

        private readonly EShopContext _dbContext;

        public ProductCategoryRepository(EShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProductCategory> All => _dbContext.ProductCategories.ToList();

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

        public async Task<ProductCategory> Get(int id)
        {
            var entity = await _dbContext.ProductCategories.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task Update(ProductCategory entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
