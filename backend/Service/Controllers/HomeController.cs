using Managers;
using Managers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : Controller
{
        [HttpPost("FindOrder")]
        public IActionResult FindOrder(int orderId)
        {
            Order order = OrderManager.FindOrder(orderId);
            return Ok(order);
        }

        [HttpPost("NewOrder")]
        public IActionResult NewOrder(int accountId, Address deliverTo)
        {
            OrderManager.NewOrder(accountId, deliverTo);
            return Ok(null);
        }
        
        [HttpPost("GetUserOrders")]
        public IActionResult GetAllOrders(int accoundId)
        {
            List<Order> userOrders = OrderManager.GetUserOrders(accoundId);
            return Ok(userOrders);
        }
    }
