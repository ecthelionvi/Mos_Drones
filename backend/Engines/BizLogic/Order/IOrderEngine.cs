using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Accessors.Address.Models;
using Accessors.Depot.Models;
using Accessors.Order.Models;

namespace Engines.BizLogic.Order
{
    public interface IOrderEngine
    {
        DateTime GetDeliveryDate(DateTime shippedDate, AddressDataModel origin, AddressDataModel destination);
        string GetOrderStatus(int orderId);
        Task<Boolean> ValidateOrderRequest(AddressDataModel destination);
        Boolean IsDeliveryRequestInRange(AddressDataModel address);
        DepotDataModel GetClosestDepot(AddressDataModel address);
        void UpdateDroneStatus();
    }
}