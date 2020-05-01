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
            return _context.Orders
                .Include(o=>o.OrderDetails)
                .ThenInclude(p=>p.Product)
                .ToList();
        }

        public Order GetOrder(int OrderId)
        {
            return _context.Orders
               .Include(o => o.OrderDetails)
               .ThenInclude(p => p.Product)
               .Where(o => o.Id == OrderId)
               .FirstOrDefault();
        }

        //public List<Order> GetUserOrders(int UserId)
        //{
        //    return _context.Orders.Where(o => o.UserId == UserId).ToList();
        //}

        public void CreateOrder(object order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }
            //_context.Orders.Add(order);
            _context.Add(order);
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

        public Order OrderExist(int OrderId)
        {
            Order order = _context.Orders.Find(OrderId);
            return order;
        }
    }
}
