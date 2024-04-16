using Accessors.DBModels;
using Managers.Models;

namespace Managers.Helpers;

public class OrderHelper
{
    public static Order OrderDataModelToOrderModel(OrderDataModel oDM)
    {
        return new Order
        {
            OrderId = oDM.OrderId,
            PackageId = oDM.PackageId,
            ShipDate = oDM.ShipDate,
            Account = oDM.Account,
            ShippedFrom = oDM.ShippedFrom,
            ShippedTo = oDM.ShippedTo
        };
    }

    public static OrderDataModel OrderToOrderDataModel(Order order)
    {
        return new OrderDataModel
        {
            OrderId = order.OrderId,
            PackageId = order.PackageId,
            ShipDate = order.ShipDate,
            Account = order.Account,
            ShippedFrom = order.ShippedFrom,
            ShippedTo = order.ShippedTo
        };
    }
}