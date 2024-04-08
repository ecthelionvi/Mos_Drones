using System.Collections.Generic;
using Accessors;
using Accessors.DBModels;
using Managers.Helpers;
using Managers.Models;

namespace Managers
{
    public class UserManager
    {
        // Example method to retrieve user orders
        public List<OrderServiceModel> GetUserOrders(string userId)
        {
            // Your logic here to retrieve user orders based on the userId
            // For example:
            // var userOrders = SomeDataAccessLayer.GetUserOrders(userId);
            // return userOrders;

            // For now, returning a dummy list of orders for demonstration
            OrderDBContext oDBContext = new OrderDBContext();
    
            List<OrderDBModel> result = oDBContext.FindAllOrders(userId);

            List<OrderServiceModel> smResults = new List<OrderServiceModel>();
            foreach (var x in result)
            {
                smResults.Add(OrderHelper.DBModelToServiceModel(x));
            }
            return smResults;
        }
    }
}