using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Repos
{
    public interface IProductRepository {
        Task<Product> GetProduct(int Id);
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetDiscountedProducts();
        Task<List<Product>> GetProductByName(string ProductName); // Search by Name
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Product product);
    }
}
