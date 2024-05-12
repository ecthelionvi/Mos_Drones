using Accessors.Order.Models;
using Managers.Address;

namespace Managers.Order.Helpers;

public class OrderHelper
{
    public static Models.Order OrderDataModelToOrderModel(OrderDataModel oDM)
    {
        return new Models.Order
        (
            oDM.OrderId,
            oDM.PackageId,
            oDM.ShipDate,
            oDM.DeliveryDate,
            oDM.AccountId,
            AddressHelper.AddressDataModelToAddress(oDM.ShippedFrom),
            AddressHelper.AddressDataModelToAddress(oDM.ShippedTo), 
            oDM.Status
        );
    }

    public static OrderDataModel OrderToOrderDataModel(Models.Order order)
    {
        return new OrderDataModel
        (
            order.OrderId,
            order.PackageId,
            order.ShipDate,
            order.DeliveryDate,
            order.AccountId,
            AddressHelper.AddressToAddressDataModel(order.ShippedFrom),
            AddressHelper.AddressToAddressDataModel(order.ShippedTo),
            order.Status
        );
    }
}