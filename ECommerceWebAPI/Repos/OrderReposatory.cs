using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Repos
{
    public class OrderReposatory : IOrderRepository
    {
        private readonly EcommercedatabaseContext _context;
        public OrderReposatory(EcommercedatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        //public List<Order> GetUserOrders(int UserId)
        //{
        //    return _context.Orders.Where(o => o.UserId == UserId).ToList();
        //}

        
        public List<Product> GetOrderProducts(int OrderId)
        {
            var ProductList = _context.Products
                .Where(p => p.OrderDetails
                .Any(o => o.OrderId == OrderId))
                .ToList();

            return ProductList;
        }

        public void CreateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Order GetOrder(int OrderId)
        {
            Order order = _context.Orders.Find(OrderId);
            return order;
        }
    }
}
