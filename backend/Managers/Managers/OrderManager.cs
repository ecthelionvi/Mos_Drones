using Accessors.Accessors;
using Accessors.DBModels;
using Engines.BizLogic;
using Managers.Helpers;
using Managers.Models;

namespace Managers;

public class OrderManager
{
    public static Order FindOrder(string packageId)
    {
        OrderDataModel orderDataModel = OrderAccessor.GetOrderWithPackageId(packageId);
        orderDataModel.Status = OrderEngine.GetOrderStatus(orderDataModel.OrderId ?? 0);
        Order order = OrderHelper.OrderDataModelToOrderModel(orderDataModel);
        return order;
    }

    public async Task<String> NewOrder(int accountId, Address deliverTo)
    {
        string response = "Invalid Order Request: Out of Range";
        AccountDataModel accountData = AccountAccessor.GetAccountWithAccountId(accountId);
        AddressDataModel destination = AddressHelper.AddressToAddressDataModel(deliverTo);

        OrderEngine oEngine = new OrderEngine();
        
        if (oEngine.ValidateOrderRequest(destination).Result)
        {
            DateTime shippedDate = DateTime.Now;
            DateTime deliveryDate = OrderEngine.GetDeliveryDate(shippedDate, accountData.AccountAddress, destination);

            OrderDataModel oDM = new OrderDataModel(null, null, shippedDate, deliveryDate, accountId,
                accountData.AccountAddress, destination, "");
            OrderAccessor orderAccessor = new OrderAccessor();
            orderAccessor.InsertOrder(oDM);
            response = "Order Successfully Added";
        }
        return response;
    }
    
    public static List<Order> GetUserOrders(int accountId)
    {
        OrderAccessor orderAccessor = new OrderAccessor();
        List<OrderDataModel> orderDataModels = OrderAccessor.GetOrderListWithAccountId(accountId);
    
        List<Order> userOrders = new List<Order>();
    
        foreach(OrderDataModel orderDataModel in orderDataModels)
        {
            orderDataModel.Status = OrderEngine.GetOrderStatus(orderDataModel.OrderId ?? 0);
            orderAccessor.UpdateOrderStatus(orderDataModel.OrderId ?? 0, orderDataModel.Status);
            
            Order o = OrderHelper.OrderDataModelToOrderModel(orderDataModel);
            userOrders.Add(o);
        }
        return userOrders;
    }

    public static List<Order> GetOrders()
    {
        List<OrderDataModel> orderDataModels = OrderAccessor.GetActiveOrders();
        
        List<Order> orders = new List<Order>();
        
        foreach (OrderDataModel orderDataModel in orderDataModels)
        {
            orderDataModel.Status = OrderEngine.GetOrderStatus(orderDataModel.OrderId ?? 0);
            orders.Add(OrderHelper.OrderDataModelToOrderModel(orderDataModel));
        }

        return orders;
    }
}