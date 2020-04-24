using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Repos
{
    public interface IProductRepository {
        IEnumerable<Product> GetProducts(Guid CategoryId);
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetDiscountedProducts(Guid CategoryId);
        Product GetProductByName(string ProductName); // Search by Name
        void CreateProduct(Guid CategoryId, Product product);
        void UpdateProducts(Product product);
        void DeleteProduct(Product product);
    }
}
