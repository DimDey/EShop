using EShop.Domain.Core;
using EShop.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Persistance.WebApi.Controllers.Products
{
    [Route("api/category")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IRepository<ProductCategory> _categories;
        public ProductCategoriesController(IRepository<ProductCategory> categories)
        {
            this._categories = categories;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCategory>> Get()
        {
            return await _categories.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ProductCategory> Get(int id)
        {
            return await _categories.Get(id);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProducts(int id)
        {
            var entity = await Get(id);

            return Ok(entity.Products);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromQuery] ProductCategory entity)
        {
            await _categories.Update(entity);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> Add([FromBody] ProductCategory entity)
        {
            await _categories.Add(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _categories.Get(id);

            await _categories.Delete(entity);
            return Ok();
        }
    }
}
