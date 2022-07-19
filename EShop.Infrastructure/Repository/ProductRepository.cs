using EShop.Infrastructure.Context;
using EShop.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly EShopContext _dbContext;

        public ProductRepository(EShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> All => _dbContext.Products.ToList();

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

        public async Task<Product> Get(int id)
        {
            var entity = await _dbContext.Products.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }
    }
}
