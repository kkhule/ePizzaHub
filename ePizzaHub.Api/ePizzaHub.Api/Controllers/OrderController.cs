using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLayer.Services;
using DataModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataModel.Exceptions;

namespace ePizzaHub.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger,IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        [HttpGet("orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            var orders = _orderRepository.GetOrdersAsync();

            _logger.LogInformation($"Total {orders.Count()} orders are returned.");
            return Ok(orders);
        }

        //[HttpGet("GetOrderByOrderdId")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Pizzas> GetOrderByOrderdId(int orderId)
        {
            var orders = _orderRepository.GetOrderByOrderIdAsync(orderId);

            if (orders == null )
            {
                _logger.LogInformation($"order with id {orderId} wasn't found when accessing order.");
                return NotFound();
            }

            _logger.LogInformation($"order with Id {orderId} is returned.");
            return Ok(orders);
        }

        [HttpGet("userorders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Pizzas>> GetOrdersByUserId(int userId)
        {
            var orders = _orderRepository.GetOrdersByUserIdAsync(userId);

            if (orders == null || orders.Count() == 0)
            {
                _logger.LogInformation($"orders of user with id {userId} wasn't found when accessing orders.");
                return NotFound();
            }

            _logger.LogInformation($"order of users with Id {userId} is returned.");
            return Ok(orders);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Pizzas>> SaveOrder(Order order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newOrder = _orderRepository.SaveOrderChangesAsync(order);

                _logger.LogInformation($"order with Id {order.Id} is created.");
                var actionName = nameof(GetOrderByOrderdId);
                var routeValues = new { id = newOrder.Id };
                return CreatedAtAction(actionName, routeValues, newOrder);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting saving order for pizza.", ex);
                throw new FileNotFoundException(ex.Message,ex.InnerException);
            }
        }
    }
}
