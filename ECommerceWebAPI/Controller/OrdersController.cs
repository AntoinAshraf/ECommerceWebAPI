using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebAPI.Repos;
using ECommerceWebAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repos;
        public OrdersController(IOrderRepository repos)
        {
            _repos = repos;
        }

        // GET: api/orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            try
            {
                var orders = _repos.GetOrders();
                if (orders != null)
                    return Ok(orders);
                else
                    return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest($"Cannot found orders :( {ex}");
            }
        }

        // GET: api/orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int OrderId)
        {
            try
            {
                Order order = _repos.GetOrder(OrderId);
                if (order != null)
                    return Ok(order);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Cannot found this order :( {ex}");
            }
            //List<Product> ProductList = _repos.GetOrderProducts(OrderId);
            //if (ProductList == null)
            //    return NotFound();
            //else
            //    return ProductList;
        }

        // POST: api/orders
        [HttpPost]
        public ActionResult Post([FromBody]OrderViewModel order)
        {
            try
            {
                var newOrder = new Order
                {
                    Id = order.OrderId,
                    Date = order.Date,
                    Status = order.Status,
                    Total = order.Total,
                    UserId = order.UserId
                };
                if(newOrder.Date==DateTime.MinValue)
                {
                    newOrder.Date = DateTime.Now;
                }
                if(ModelState.IsValid)
                {
                    var vm = new OrderViewModel()
                    {
                        OrderId = order.OrderId,
                        Date = order.Date,
                        Status = order.Status,
                        Total = order.Total,
                        UserId = order.UserId
                    };
                    _repos.CreateOrder(vm);
                    return Created($"api/orders/{vm.OrderId}", order);
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to save a new order :( {ex}");
            }
           
        }

        // PUT: api/orders/5
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

        // DELETE: api/orders/5
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)  ///?????????????????
        {
            var order = _repos.OrderExist(id);
            if (order == null)
            {
                return NotFound();
            }

            _repos.DeleteOrder(order);

            return order;
        }
    }
}