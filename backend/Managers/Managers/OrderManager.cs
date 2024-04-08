
using Accessors;
using Accessors.DBModels;
using Managers.Helpers;
using Managers.Models;

namespace Managers
{
    public class OrderManager
    {
        // Example method to track a package
        public OrderServiceModel TrackPackage(string packageId)
        {
            // Your logic here to track the package based on the packageId
            // For example:
            // var order = SomeDataAccessLayer.GetOrderByPackageId(packageId);
            // return order;

            // For now, returning a dummy order for demonstration
            OrderDBContext oDBContext = new OrderDBContext();
            
            OrderDBModel result =  oDBContext.FindSignleOrder("123");
            return OrderHelper.DBModelToServiceModel(result);
        }
    }
}