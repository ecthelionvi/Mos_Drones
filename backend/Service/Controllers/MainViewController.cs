using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json.Nodes;
using Managers;
using Microsoft.AspNetCore.Identity;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainViewController : Controller
    {
        private readonly OrderManager _orderManager;
        private readonly UserManager _userManager;

        public MainViewController(OrderManager orderManager, UserManager userManager)
        {
            _orderManager = orderManager;
            _userManager = userManager;
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
        public IActionResult GetUserOrders(string userId)
        {
            // Call the appropriate method from your UserManager to get user orders
            var userOrders = _userManager.GetUserOrders(userId);
            return Ok(userOrders);
        }
    }
}