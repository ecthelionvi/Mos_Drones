using Accessors.Accessors;
using Accessors.DBModels;
using Managers.Helpers;
using Managers.Models;

namespace Managers;

public class OrderManager
{
    public static Order FindOrder(int orderId)
    {
        OrderDataModel orderData = OrderAccessor.GetOrderWithOrderId(orderId);
        Order order = OrderHelper.OrderDataModelToOrderModel(orderData);
        return order;
    }
}