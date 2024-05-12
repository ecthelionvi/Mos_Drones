using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json.Nodes;
using Managers;
using Managers.Drone.Models;
using Managers.Order;
using Managers.Order.Models;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : Controller
{
    private readonly IOrderManager _orderManager;
    
    public AdminController(IOrderManager orderManager)
    {
        _orderManager = orderManager;
    }
    [HttpGet("GetDrones")]
    public JsonResult GetDrones()
    {
        List<Drone> droneList = _orderManager.GetDrones();
        return new JsonResult(droneList);
    }
}