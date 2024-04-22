using Accessors.DBModels;
using Managers.Models;

namespace Managers.Helpers;

public class OrderHelper
{
    public static Order OrderDataModelToOrderModel(OrderDataModel oDM)
    {
        return new Order
        (
            oDM.OrderId,
            oDM.PackageId,
            oDM.ShipDate,
            oDM.DeliveryDate,
            AccountHelper.AccountDataModelToAccount(oDM.Account),
            AddressHelper.AddressDataModelToAddress(oDM.ShippedFrom),
            AddressHelper.AddressDataModelToAddress(oDM.ShippedTo)
        );
    }

    public static OrderDataModel OrderToOrderDataModel(Order order)
    {
        return new OrderDataModel
        (
            order.OrderId,
            order.PackageId,
            order.ShipDate,
            order.DeliveryDate,
            AccountHelper.AccountToAccountDataModel(order.Account),
            AddressHelper.AddressToAddressDataModel(order.ShippedFrom),
            AddressHelper.AddressToAddressDataModel(order.ShippedTo)
        );
    }
}