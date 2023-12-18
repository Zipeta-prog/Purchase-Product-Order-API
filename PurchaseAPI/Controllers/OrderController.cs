using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaseAPI.Models;
using PurchaseAPI.Services.IServices;
using PurchaseAPI.Services;
using PurchaseAPI.Entities.Dto;

namespace PurchaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly UserService _userService;

        public OrderController(OrderService orderService, UserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }

        // GET: api/orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] AddOrderDto orderDto)
        {
            try
            {
                // Validate order data
                if (!ModelState.IsValid) return BadRequest(ModelState);

                // Get user ID from token
                var userId = int.Parse(User.FindFirst("UserId").Value);

                // Create order object
                var order = new Order
                {
                    UserId = userId,
                    CustomerName = orderDto.CustomerName,
                    OrderDate = DateTime.UtcNow,
                    TotalPrice = orderDto.TotalPrice,
                    OrderItems = orderDto.OrderItems.Select(item => new OrderItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Price,
                    }).ToList()
                };

                // Create order
                var createdOrder = await _orderService.CreateOrder(order);

                // Calculate and update total price
                createdOrder.TotalPrice = createdOrder.OrderItems.Sum(item => item.Price * item.Quantity);
                await _orderService.UpdateOrder(createdOrder);

                return CreatedAtRoute("GetOrder", new { id = createdOrder.Id }, createdOrder);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex.Message);
            }
        }

        private ActionResult<Order> InternalServerError(string message)
        {
            throw new NotImplementedException();
        }

        // PUT: api/orders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderUpdateDto orderDto)
        {
            try
            {
                // Validate order data
                if (!ModelState.IsValid) return BadRequest(ModelState);

                // Get order from database
                var existingOrder = await _orderService.GetOrderById(id);
                if (existingOrder == null) return NotFound();

                // Update relevant fields
                existingOrder.CustomerName = orderDto.CustomerName;
                existingOrder.OrderItems = orderDto.OrderItems.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                }).ToList();

                // Calculate and update total price
                existingOrder.TotalPrice = existingOrder.OrderItems.Sum(item => item.Price * item.Quantity);

                // Update order
                await _orderService.UpdateOrder(existingOrder);

                return NoContent();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex.Message);
            }
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var order = await _orderService.GetOrderById(id);
                if (order == null) return NotFound();

                await _orderService.DeleteOrder(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex.Message);
            }
        }
    }
}
