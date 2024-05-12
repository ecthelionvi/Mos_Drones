namespace Managers.Order;

public interface IOrderManager
{
    List<Models.Order> GetUserOrders(int accountId);
    Models.Order FindOrder(string packageId);
    Task<string> NewOrder(int accountId, Address.Address deliverTo);
    List<Models.Order> GetAllOrders();
    
    List<Managers.Drone.Models.Drone> GetDrones();
}