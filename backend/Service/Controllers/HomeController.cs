using Managers;
using Managers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : Controller
{
        [HttpPost("FindOrder")]
        public IActionResult FindOrder([FromBody] int orderId)
        {
            Order order = OrderManager.FindOrder(orderId);
            return Ok(order);
        }

        [HttpPost("NewOrder")]
        public IActionResult NewOrder([FromBody] int accountId, Address deliverTo)
        {
            OrderManager.NewOrder(accountId, deliverTo);
            return Ok(null);
        }
        
        [HttpPost("GetUserOrders")]
        public IActionResult FindOrder([FromBody] int accoundId)
        {
            List<Order> userOrders = OrderManager.GetUserOrders(accoundId);
            return Ok(userOrders);
        }
    }
