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

        public static string getOrderStatus(DateTime deliveryDate)
        {
            int compare = deliveryDate.CompareTo(DateTime.Now);
            return compare < 0 ? "Package-In-Transit" : "delivered";
        }

        public static string getAdminOrderStatus(DateTime deliveryDate)
        {
            int compare = deliveryDate.CompareTo(DateTime.Now);
            return compare < 0 ? "Package-In-Transit" : "delivered";
        }

        public static Boolean validateOrderRequest(AddressDataModel destination)
        {
            //TODO check if in range
            return true;
        }
    }
}
