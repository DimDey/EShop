using Microsoft.AspNetCore.Mvc;
using EShop.Domain.Core;
using EShop.Domain.Interfaces;

namespace EShop.Persistance.WebApi.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> productContext;

        public ProductController(IRepository<Product> productContext)
        {
            this.productContext = productContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await productContext.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await productContext.Get(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] Product value)
        {
            await productContext.Update(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product value)
        {
            await productContext.Add(value);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await productContext.Get(id);

            await productContext.Delete(entity);
            return Ok();
        }
    }
}
