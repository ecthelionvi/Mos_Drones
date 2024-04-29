using Accessors.Accessors;
using Accessors.DBModels;
using Engines.BizLogic;
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

    public static Boolean NewOrder(int accountId, Address deliveryTo)
    {
        AccountDataModel accountData = AccountAccessor.GetAccountWithAccountId(accountId);
        AddressDataModel destination = AddressHelper.AddressToAddressDataModel(deliveryTo);

        if (OrderEngine.validateOrderRequest(destination))
        {
            DateTime shippedDate = DateTime.Now;
            DateTime deliveryDate = OrderEngine.getDeliveryDate(shippedDate, accountData.AccountAddress, destination);

            OrderDataModel oDM = new OrderDataModel(null, null, shippedDate, deliveryDate, accountId,
                accountData.AccountAddress, destination);
        
            OrderAccessor.InsertOrder(oDM);
            return true;
        }
        return false;
    }
    
    public static List<Order> GetUserOrders(int accountId)
    {
        List<OrderDataModel> orderDataModels = OrderAccessor.GetOrderListWithAccountId(accountId);
    
        List<Order> userOrders = new List<Order>();
    
        foreach(OrderDataModel orderDataModel in orderDataModels)
        {
            Order o = OrderHelper.OrderDataModelToOrderModel(orderDataModel);
            userOrders.Add(o);
        }
        return userOrders;
    }
}