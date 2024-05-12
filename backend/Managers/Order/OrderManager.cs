using Accessors.Account;
using Accessors.Account.Models;
using Accessors.Address;
using Accessors.Address.Models;
using Accessors.Depot;
using Accessors.Drone;
using Accessors.Drone.Models;
using Accessors.Order;
using Accessors.Order.Models;
using Engines.BizLogic;
using Engines.BizLogic.Order;
using Managers.Address;
using Managers.Drone.Helpers;
using Managers.Order.Helpers;
using Managers.Order.Models;

namespace Managers.Order;

public class OrderManager : IOrderManager
{
    private readonly IOrderAccessor _orderAccessor;
    private readonly IAccountAccessor _accountAccessor;
    private readonly IAddressAccessor _addressAccessor;
    private readonly IDroneAccessor _droneAccessor;
    private readonly IOrderEngine _orderEngine;

    public OrderManager(IOrderAccessor orderAccessor, IAccountAccessor accountAccessor, IAddressAccessor addressAccessor, IDroneAccessor droneAccessor, IDepotAccessor depotAccessor)
    {
        _orderAccessor = orderAccessor;
        _accountAccessor = accountAccessor;
        _addressAccessor = addressAccessor;
        _droneAccessor = droneAccessor;
        
        _orderEngine = new OrderEngine(_orderAccessor, depotAccessor, _droneAccessor);
    }
    public List<Models.Order> GetUserOrders(int accountId)
    {
        List<OrderDataModel> orderDataModels = _orderAccessor.GetOrderListWithAccountId(accountId);
        List<Models.Order> userOrders = new List<Models.Order>();
    
        foreach(OrderDataModel orderDataModel in orderDataModels)
        {
            orderDataModel.Status = _orderEngine.GetOrderStatus(orderDataModel.OrderId ?? 0);
            _orderAccessor.UpdateOrderStatus(orderDataModel.OrderId ?? 0, orderDataModel.Status);
            
            Models.Order o = OrderHelper.OrderDataModelToOrderModel(orderDataModel);
            userOrders.Add(o);
        }
        return userOrders;
    }
    public Models.Order FindOrder(string packageId)
    {
        OrderDataModel orderDataModel = _orderAccessor.GetOrderWithPackageId(packageId);
        orderDataModel.Status = _orderEngine.GetOrderStatus(orderDataModel.OrderId ?? 0);
        Models.Order order = OrderHelper.OrderDataModelToOrderModel(orderDataModel);
        return order;
    }

    public async Task<String> NewOrder(int accountId, Address.Address deliverTo)
    {
        string response = "Invalid Order Request: Out of Range";
        AccountDataModel accountData = _accountAccessor.GetAccountWithAccountId(accountId);
        AddressDataModel destination = AddressHelper.AddressToAddressDataModel(deliverTo);
        
        if (_orderEngine.ValidateOrderRequest(destination).Result)
        {
            DateTime shippedDate = DateTime.Now;
            DateTime deliveryDate = _orderEngine.GetDeliveryDate(shippedDate, accountData.AccountAddress, destination);

            OrderDataModel oDM = new OrderDataModel(null, null, shippedDate, deliveryDate, accountId,
                accountData.AccountAddress, destination, "");
            int id = await _orderAccessor.InsertOrder(oDM);
            response = id != - 1 ? "Order Successfully Added" : "Error Adding Order.";
        }
        return response;
    }

    public List<Models.Order> GetAllOrders()
    {
        List<OrderDataModel> orderDataModels = _orderAccessor.GetActiveOrders();
        
        List<Models.Order> orders = new List<Models.Order>();
        
        foreach (OrderDataModel orderDataModel in orderDataModels)
        {
            orderDataModel.Status = _orderEngine.GetOrderStatus(orderDataModel.OrderId ?? 0);
            orders.Add(OrderHelper.OrderDataModelToOrderModel(orderDataModel));
        }

        return orders;
    }
    
    public List<Drone.Models.Drone> GetDrones()
    {
        _orderEngine.UpdateDroneStatus();
        
        List<DroneDataModel> droneList = _droneAccessor.GetDroneList();
        List<Drone.Models.Drone> drones = new List<Drone.Models.Drone>();
        
        foreach (DroneDataModel droneDataModel in droneList)
        {
            drones.Add(DroneHelper.ConvertDroneDataModelToDroneModel(droneDataModel));
        }
        
        return drones;
    }
}