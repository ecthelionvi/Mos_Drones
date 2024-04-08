using System.Collections;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json.Nodes;
using Managers;
using Managers.Models;
using Microsoft.AspNetCore.Identity;

namespace Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainViewController : ControllerBase
    {
        private readonly ILogger<MainViewController> _logger;
        private readonly OrderManager _orderManager = new OrderManager();
        private readonly UserManager _userManager = new UserManager();

        public MainViewController(ILogger<MainViewController> logger)
        {
            _logger = logger;
        }
        

        [HttpPost("TrackPackage")]
        public IActionResult TrackPackage(string packageId)
        {
            // Call the appropriate method from your OrderManager to track the package
            var order = _orderManager.TrackPackage(packageId);
            if (order == null)
            {
                return NotFound("Package not found");
            }
            return Ok(order);
        }
        
        [HttpGet("GetUserOrders")]
        public IEnumerable<OrderServiceModel> GetUserOrders(string userId)
        {
            // Call the appropriate method from your UserManager to get user orders
            
            //url
            //http://localhost:3001/api/MainView/GetUserOrders?userId=123
            
            //Json Response
            // [
            // {
            //     "id": "1",
            //     "deliveryDate": "2024-04-10",
            //     "status": "Pending"
            // },
            // {
            //     "id": "2",
            //     "deliveryDate": "2024-03-30",
            //     "status": "Delivered"
            // }
            // ]
            var userOrders = _userManager.GetUserOrders(userId);
            return userOrders;
        }
    }
}