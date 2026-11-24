using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using System.Threading.Tasks;
using System.Collections.Generic;  
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _ordersService.GetAllOrders();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var order = await _ordersService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            await _ordersService.AddOrder(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);


        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async   Task<IActionResult>  Put(int id, [FromBody] string value)
        {
            var existingOrder = await _ordersService.GetOrder(id);
            if (existingOrder == null)
            {
                return NotFound();
            }
            var updatedOrderDetails = System.Text.Json.JsonSerializer.Deserialize<Order>(value);
            if (updatedOrderDetails == null)
            {
                return BadRequest("Invalid order data.");
            }
            await _ordersService.UpdateOrder(id, updatedOrderDetails);
            return NoContent();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
