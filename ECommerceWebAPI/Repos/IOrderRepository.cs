using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Repos
{
    public interface IOrderRepository {
        IEnumerable<Order> GetOrders();

        Order GetOrder(int OrderId);
        Order OrderExist(int OrderId);
        void CreateOrder(object order);
        void UpdateOrder(Order product);
        void DeleteOrder(Order order);
    }
}
