using Managers;
using Managers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : Controller
{
    [HttpPost("GetUserOrders")]
    public JsonResult GetAllOrders(int id)
    {
        List<Order> userOrders = OrderManager.GetUserOrders(id);
        return Json(userOrders);
    }

    [HttpGet("FindOrder/{packageId}")]
    public JsonResult FindOrder(string packageId)
    {
        Order order = OrderManager.FindOrder(packageId);
        return Json(order);
    }

    [HttpPost("NewOrder")]
    public IActionResult NewOrder([FromBody] Address deliverTo)
    {
        var response = "Please Login";
        if (LoginController.AccountId != null)
        {
            OrderManager orderManager = new OrderManager();
            response = orderManager.NewOrder(LoginController.AccountId ?? 0, deliverTo).Result;
        }

        return Ok(response);
    }
}
