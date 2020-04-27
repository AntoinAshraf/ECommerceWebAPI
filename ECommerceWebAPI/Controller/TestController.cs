using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebAPI.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IOrderRepository _repos;
        public TestController(IOrderRepository repos)
        {
            _repos = repos;
        }

        // GET: api/Test
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _repos.GetOrders();
        }

        // GET: api/Test/5
        [HttpGet("{id}")]
        public ActionResult<List<Product>> Get(int OrderId)
        {
            List<Product> ProductList = _repos.GetOrderProducts(OrderId);
            if (ProductList == null)
                return NotFound();
            else
                return ProductList;
        }

        // POST: api/Test
        [HttpPost]
        public ActionResult Post(Order order)
        {
            _repos.CreateOrder(order);
            return Created("ddhdhhd", order);
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }
            _repos.UpdateOrder(order);

            return NoContent();
        }

        // DELETE: api/test/5
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {
            var order = _repos.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }

            _repos.DeleteOrder(order);

            return order;
        }
    }
}