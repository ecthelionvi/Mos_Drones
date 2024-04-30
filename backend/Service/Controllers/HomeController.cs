using Managers;
using Managers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : Controller
{
    public static int AccountId = -1;   
    
    [HttpPost("FindOrder")]
    public IActionResult FindOrder([FromBody]int orderId)
    {
        Order order = OrderManager.FindOrder(orderId);
        return Ok(order);
    }

    [HttpPost("NewOrder")]
    public IActionResult NewOrder([FromBody]Address deliverTo)
    {
        string response = "Please Login";
        if (AccountId != -1)
        {
            response = OrderManager.NewOrder(AccountId, deliverTo);
        }
        return Ok(response);
    }
    
    [HttpPost("GetUserOrders")]
    public JsonResult GetAllOrders(int id)
    {
        List<Order> userOrders = OrderManager.GetUserOrders(id);
        return Json(userOrders);
    }
}
