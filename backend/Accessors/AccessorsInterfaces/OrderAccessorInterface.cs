using System.Data.SqlClient;
using System.Security.Principal;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    interface IOrderAccessor
    {
        public static OrderDataModel GetOrderWithOrderId(int orderId);
        public static OrderDataModel GetOrderWithPackageId(string packageId);
        public static List<OrderDataModel> GetOrderListWithAccountId(int accountId);
        public static int InsertOrder(OrderDataModel order);
    }
}