using System;
using Accessors.DBModels;

namespace Engines.BizLogic 
{
    public class OrderEngine
    {
        public static DateTime getDeliveryDate(DateTime shippedDate, AddressDataModel origin, AddressDataModel destination)
        {
            //TODO:add more complex logic using 
            return shippedDate.AddDays(3);
        }

        public static void getOrderStatus()
        {
            // gives either, delivered, Package-In-transit, Drone-in-route
        }

        public static void getAdminOrderStatus()
        {
            //this gives a more descriptive status for admin
            //En-route to <Depot_9>/<Desination>/<Pickup>
        }

        public static void validateOrderRequest()
        {
            //this should validate that the requested delivery address is in range of a depot
        }
    }
}
