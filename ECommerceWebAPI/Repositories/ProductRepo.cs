using ECommerceWebAPI.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Repositories
{
    public class ProductRepo : IProductRepository {
        EcommercedatabaseContext eCommerceDBContext = new EcommercedatabaseContext();

        public async Task<bool> CreateProduct(Product product) {
            eCommerceDBContext.Products.Add(product);
            await eCommerceDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(Product product) {
            eCommerceDBContext.Products.Remove(product);
            await eCommerceDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetDiscountedProducts() {
            return await eCommerceDBContext.Products.Where(prod => prod.IsPromoted == true).ToListAsync();
        }

        public async Task<List<Product>> GetProductByName(string ProductName) {
            return await eCommerceDBContext.Products.Where(prod => prod.Title.Contains(ProductName)).ToListAsync();
        }

        public async Task<Product> GetProduct(int Id) {
            return await eCommerceDBContext.Products.FindAsync(Id);
        }

        public async Task<List<Product>> GetProducts() {
            return await eCommerceDBContext.Products.ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product) {
            eCommerceDBContext.Entry(product).State = EntityState.Modified;
            await eCommerceDBContext.SaveChangesAsync();
            return true;
        }

        public bool ProductExists(int id) {
            return eCommerceDBContext.Products.Any(prod => prod.Id == id);
        }
    }
}
