using Managers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : Controller
{
        [HttpPost("FindOrder")]
        public IActionResult FindOrder([FromBody] string orderId)
        {
            // In a real scenario, you would fetch the order from the database based on the orderId.
            // For demonstration purposes, let's assume you have some mock data.
            var order = new Order
            {
                OrderId = 12345, // Sample OrderId
                PackageId = "PKG123", // Sample PackageId
                ShipDate = DateTime.UtcNow, // Sample ShipDate
                Account = new Account
                {
                    // Populate Account properties
                },
                ShippedFrom = new Address
                {
                    // Populate ShippedFrom properties
                },
                ShippedTo = new Address
                {
                    // Populate ShippedTo properties
                }
            };

            // Return the order as JSON response
            return Ok(order);
        }

        [HttpPost("NewOrder")]
        public IActionResult NewOrder([FromBody] Order order)
        {
            // Validate if order object is null
            if (order == null)
            {
                return BadRequest("Order object is null");
            }

            try
            {
                // In a real scenario, you would insert the order into the database.
                // For demonstration purposes, let's assume insertion is successful.

                // Here you can add the logic to populate all data, as mentioned in the comment.
                // This might involve interacting with various services or engines to get the necessary data.

                // Assuming insertion is successful, return a success response.
                return Ok("Order created successfully");
            }
            catch (Exception ex)
            {
                // In case of any exception during order creation, return a 500 Internal Server Error.
                return StatusCode(500, $"An error occurred while creating the order: {ex.Message}");
            }
        }
    }
}