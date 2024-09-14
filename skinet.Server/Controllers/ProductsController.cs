using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace skinet.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
        public class ProductsController(IGenericRepository<Product> repo) : ControllerBase
    {
        private readonly IGenericRepository<Product> repo = repo;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string? brand, string? type, string? sort)
        {
            return Ok(await repo.ListAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);
            
            if (product == null) return NotFound();
 
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            repo.Add(product);
           if (await repo.SaveAllAsync())
            {
                return CreatedAtAction("GetProducts", new { Id = product.Id }, product);
            }

            return BadRequest("Problem creating product");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (product.Id != id || !ProductExists(id)) return BadRequest("This product can not be updated");

            repo.Update(product);
            
             if(await repo.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("Problem updating the product");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);
            
            if (product == null) return NotFound();

            repo.Remove(product);

            if (await repo.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("Problem deleting the product");

        }

        [HttpGet("brands")]
        public async Task<ActionResult> GetBrands()
        {
            // TODO: GetBrands
            return Ok();
        }
        
        [HttpGet("types")]
        public async Task<ActionResult> GetTypes()
        {
            //TODO: GetTypes
            return Ok();
        }

        private bool ProductExists(int id)
        {
            return repo.Exists(id);
        }
    }
}
