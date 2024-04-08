using Accessors.DBModels;

namespace Accessors;

public class OrderDBContext
{
    
    //used for adding an order to the user account.
    public OrderDBModel FindSignleOrder(string id)
    {
        
        //hits sql and looks for matching order
        return new OrderDBModel { Id = "123456", Status = "In transit", DeliveryDate = "2024-04-10" };
    }
    
    //Used for getting every order a user is tracking
    public List<OrderDBModel> FindAllOrders(string userId)
    {
        List<OrderDBModel> order = new List<OrderDBModel>
        {
            new OrderDBModel { Id = "1", Status = "Pending", DeliveryDate = "2024-04-10" },
            new OrderDBModel { Id = "2", Status = "Delivered", DeliveryDate = "2024-03-30" }
        };
        
        return order;
    }
}