using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Repos
{
    public interface IOrderRepository {
        IEnumerable<Order> GetOrders();
        List<Product> GetOrderProducts(int OrderId);
        Order GetOrder(int OrderId);

        //IEnumerable<Order> GetUserOrders(Guid UsrID);
        //
        void CreateOrder(Order order);
        void UpdateOrder(Order product);
        void DeleteOrder(Order order);
    }
}
