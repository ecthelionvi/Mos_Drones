using System;
using Accessors.DBModels;

namespace Engines.BizLogic 
{
    public class OrderEngine
    {
        public static DateTime getDeliveryDate(DateTime shippedDate, AddressDataModel origin, AddressDataModel destination)
        {
            //TODO:add more complex logic
            return shippedDate.AddDays(3);
        }
    }
}
