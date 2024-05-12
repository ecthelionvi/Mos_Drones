using Managers;
using Managers.Address;
using Managers.Drone.Models;
using Managers.Order;
using Managers.Order.Models;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : Controller
{
    private readonly IOrderManager _orderManager;

    public HomeController(IOrderManager orderManager)
    {
        _orderManager = orderManager;
    }
    
    [HttpPost("GetUserOrders")]
    public JsonResult GetAllOrders(int id)
    {
        List<Order> userOrders = _orderManager.GetUserOrders(id);
        return Json(userOrders);
    }

    [HttpGet("FindOrder/{packageId}")]
    public JsonResult FindOrder(string packageId)
    {
        Order order = _orderManager.FindOrder(packageId);
        return Json(order);
    }

    [HttpPost("NewOrder")]
    public IActionResult NewOrder([FromBody] Address deliverTo)
    {
        var response = "Please Login";
        if (LoginController.AccountId != null)
        {
            response = _orderManager.NewOrder(LoginController.AccountId ?? 0, deliverTo).Result;
        }

        return Ok(response);
    }

    [HttpGet("GetOrders")]
    public JsonResult GetOrders()
    {
        List<Order> orders = _orderManager.GetAllOrders();
        return new JsonResult(orders);
    }
}
