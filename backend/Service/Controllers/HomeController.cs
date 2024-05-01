using Managers;
using Managers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : Controller
{
    [HttpPost("FindOrder")]
    public IActionResult FindOrder([FromBody]int orderId)
    {
        Order order = OrderManager.FindOrder(orderId);
        return Ok(order);
    }

    [HttpPost("NewOrder")]
    public IActionResult NewOrder([FromBody]Address deliverTo)
    {
        var response = "Please Login";
        if (LoginController.AccountId != null)
        {
            response = OrderManager.NewOrder(LoginController.AccountId ?? 0, deliverTo);
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
