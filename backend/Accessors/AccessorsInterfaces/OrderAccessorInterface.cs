using System.Data.SqlClient;
using System.Security.Principal;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    interface IOrderAccessor
    {
        OrderDataModel GetOrderWithOrderId(int orderId);
        OrderDataModel GetOrderWithPackageId(string packageId);
        List<OrderDataModel> GetOrderListWithAccountId(int accountId);
        int InsertOrder(OrderDataModel order);
    }
}