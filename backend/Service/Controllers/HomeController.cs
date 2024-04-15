using Managers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : Controller
{
    [HttpPost]
    public JsonResult FindOrder(String orderid)
    {
        //should hit db to look for order based on order id.
        //returns order object
        return new JsonResult();
    }
    
    [HttpPost]
    public JsonResult NewOrder(Order order)
    {
        //creates a new Order object
        //goes through engines to populate all data
        //inserts into db
        
    }
    
}