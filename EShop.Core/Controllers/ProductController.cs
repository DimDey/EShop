using EShop.Infrastructure.Models;
using EShop.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Api.Controllers
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
            return productContext.All;
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
