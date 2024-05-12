using System.Data.SqlClient;
using System.Numerics;
using System.Security.Principal;
using Accessors.Order.Models;

namespace Accessors.Order
{
    public interface IOrderAccessor
    {
        OrderDataModel GetOrderWithOrderId(int orderId);
        OrderDataModel GetOrderWithPackageId(string packageId);
        List<OrderDataModel> GetOrderListWithAccountId(int accountId);
        Task<int> InsertOrder(OrderDataModel order);
        public void UpdateOrderStatus(int orderId, string status);
        public List<OrderDataModel> GetActiveOrders();
    }
}