using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerceWebAPI;
using ECommerceWebAPI.Repositories;

namespace ECommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepo ProdRepoCtx = new ProductRepo();
        private readonly EcommercedatabaseContext ctx;

        public ProductsController( EcommercedatabaseContext _ctx)
        {
            ctx = _ctx;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await ProdRepoCtx.GetProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) {
            var product = await ProdRepoCtx.GetProduct(id);

            if (product == null) {
                return NotFound();
            }
            return product;
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetDiscountedProducts() {
            return await ProdRepoCtx.GetDiscountedProducts();
        }

        public async Task<ActionResult<IEnumerable<Product>>> getproductByName(string prodTitle) {
            return await ProdRepoCtx.GetProductByName(prodTitle);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id) {
                return BadRequest();
            }
            try
            {
                await ProdRepoCtx.UpdateProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await ProdRepoCtx.CreateProduct(product);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await ProdRepoCtx.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            await ProdRepoCtx.DeleteProduct(product);
            //_context.Products.Remove(product);
            //await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return ProdRepoCtx.ProductExists(id);
        }
    }
}
