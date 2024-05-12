using System.Data.SqlClient;
using Accessors.Account;
using Accessors.Account.Models;
using Accessors.Address;
using Accessors.Address.Models;
using Accessors.Order.Models;

namespace Accessors.Order
{
    public class OrderAccessor : IOrderAccessor
    {
        private readonly SqlConnection _connection;
        private readonly IAccountAccessor _accountAccessor;
        private readonly IAddressAccessor _addressAccessor;

        public OrderAccessor(SqlConnection connection, IAccountAccessor accountAccessor, IAddressAccessor addressAccessor)
        {
            _connection = connection;
            _accountAccessor = accountAccessor;
            _addressAccessor = addressAccessor;
        }
        public OrderDataModel GetOrderWithOrderId(int orderId)
        {
            OrderDataModel order = new OrderDataModel();

            string query = "SELECT * FROM [Order] WHERE orderId = @OrderId";

            using (_connection)
            {
                try
                {
                    _connection.Open();
                    using (SqlCommand command = new SqlCommand(query,_connection))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows && reader.Read())
                        {
                            string packageId = reader.GetString(reader.GetOrdinal("packageId"));
                            DateTime shipDate = reader.GetDateTime(reader.GetOrdinal("ship_date"));
                            DateTime deliveryDate = reader.GetDateTime(reader.GetOrdinal("deliveryDate"));
                            int accountId = reader.GetInt32(reader.GetOrdinal("accountId"));
                            int shippedFrom = reader.GetInt32(reader.GetOrdinal("shipped_from"));
                            int shippedTo = reader.GetInt32(reader.GetOrdinal("shipped_to"));
                            string status = reader.GetString(reader.GetOrdinal("status"));

                            AccountDataModel account = _accountAccessor.GetAccountWithAccountId(accountId);
                            AddressDataModel origin = _addressAccessor.GetAddress(shippedFrom);
                            AddressDataModel destination = _addressAccessor.GetAddress(shippedTo);

                            order = new OrderDataModel(orderId, packageId, shipDate, deliveryDate, accountId, origin,
                                destination, status);
                        }

                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
            return order;
        }
        
        public OrderDataModel GetOrderWithPackageId(string packageId)
        {
            OrderDataModel order = new OrderDataModel();

            string query = "SELECT * FROM [Order] WHERE packageId = @PackageId";

            using (_connection)
            {
                try
                {
                    _connection.Open();
                    using (SqlCommand command = new SqlCommand(query,_connection))
                    {
                        command.Parameters.AddWithValue("@PackageId", packageId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows && reader.Read())
                        {
                            int orderId = reader.GetInt32(reader.GetOrdinal("orderId"));
                            DateTime shipDate = reader.GetDateTime(reader.GetOrdinal("ship_date"));
                            DateTime deliveryDate = reader.GetDateTime(reader.GetOrdinal("deliveryDate"));
                            int accountId = reader.GetInt32(reader.GetOrdinal("accountId"));
                            int shippedFrom = reader.GetInt32(reader.GetOrdinal("shipped_from"));
                            int shippedTo = reader.GetInt32(reader.GetOrdinal("shipped_to"));
                            string status = reader.GetString(reader.GetOrdinal("status"));

                            AddressDataModel origin = _addressAccessor.GetAddress(shippedFrom);
                            AddressDataModel destination = _addressAccessor.GetAddress(shippedTo);

                            order = new OrderDataModel(orderId, packageId, shipDate, deliveryDate, accountId, origin,
                                destination, status);
                        }

                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
            return order;
        }
        
        public List<OrderDataModel> GetOrderListWithAccountId(int accountId)
        {
            List<OrderDataModel> orderList = new List<OrderDataModel>();
            string query =
                "SELECT o.* FROM [Order] o JOIN [Account] a ON o.accountId = a.accountId WHERE o.accountId = @AccountId";

            using (_connection)
            {
                try
                {
                    _connection.Open();
                    using (SqlCommand command = new SqlCommand(query,_connection))
                    {
                        command.Parameters.AddWithValue("@AccountId", accountId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int orderId = reader.GetInt32(reader.GetOrdinal("orderId"));
                                string packageId = reader.GetString(reader.GetOrdinal("packageId"));
                                DateTime shipDate = reader.GetDateTime(reader.GetOrdinal("ship_date"));
                                DateTime deliveryDate = reader.GetDateTime(reader.GetOrdinal("deliveryDate"));
                                int shippedFrom = reader.GetInt32(reader.GetOrdinal("shipped_from"));
                                int shippedTo = reader.GetInt32(reader.GetOrdinal("shipped_to"));
                                string status = reader.GetString(reader.GetOrdinal("status"));

                                AddressDataModel origin = _addressAccessor.GetAddress(shippedFrom);
                                AddressDataModel destination = _addressAccessor.GetAddress(shippedTo);

                                OrderDataModel o = new OrderDataModel(orderId, packageId, shipDate, deliveryDate, accountId,
                                    origin, destination, status);
                                orderList.Add(o);
                            }
                        }
                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
            return orderList;
        }
        
        public async Task<int> InsertOrder(OrderDataModel order)
        {
            string packageId = Guid.NewGuid().ToString("N").Substring(0, 16);
            DateTime shipDate = DateTime.Now;
            AccountDataModel orderAccount = _accountAccessor.GetAccountWithAccountId(order.AccountId);

            string selectQuery = @"SELECT accountId FROM Account WHERE email = @Email";

            string insertQuery =
                @"INSERT INTO [Order] (packageId, ship_date, deliveryDate, accountId, shipped_from, shipped_to, status) 
                                   VALUES (@PackageId, @ShipDate, @DeliveryDate, @AccountId, @ShippedFrom, @ShippedTo, @Status); SELECT SCOPE_IDENTITY();";

            int orderId = -1;

            using (_connection)
            {
                try
                {
                    _connection.Open();

                    using (SqlCommand selectCommand = new SqlCommand(selectQuery,_connection))
                    {
                        selectCommand.Parameters.AddWithValue("@Email", orderAccount.Email);

                        object account = selectCommand.ExecuteScalar();
                        int accountId = Convert.ToInt32(account);

                        int originId = await _addressAccessor.InsertAddress(order.ShippedFrom);
                        int destinationId = await _addressAccessor.InsertAddress(order.ShippedTo);
                        
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery,_connection))
                        {
                            insertCommand.Parameters.AddWithValue("@PackageId", packageId);
                            insertCommand.Parameters.AddWithValue("@ShipDate", shipDate);
                            insertCommand.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
                            insertCommand.Parameters.AddWithValue("@AccountId", accountId);
                            insertCommand.Parameters.AddWithValue("@ShippedFrom", originId);
                            insertCommand.Parameters.AddWithValue("@ShippedTo", destinationId);
                            insertCommand.Parameters.AddWithValue("@Status", order.Status);

                            // Insert the record and get its id
                            object orderResult = insertCommand.ExecuteScalar();
                            orderId = Convert.ToInt32(orderResult);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
            return orderId;
        }
        
        public List<OrderDataModel> GetActiveOrders()
        {
            string query = "SELECT * FROM [Order] WHERE status != @Status";
            List<OrderDataModel> orderList = new List<OrderDataModel>();
            using (_connection)
            {
                try
                {
                    _connection.Open();
                    using (SqlCommand command = new SqlCommand(query,_connection))
                    {
                        command.Parameters.AddWithValue("@Status", "Delivered");
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int orderId = reader.GetInt32(reader.GetOrdinal("orderId"));
                                string packageId = reader.GetString(reader.GetOrdinal("packageId"));
                                int accountId = reader.GetInt32(reader.GetOrdinal("accountId"));
                                DateTime shipDate = reader.GetDateTime(reader.GetOrdinal("ship_date"));
                                DateTime deliveryDate = reader.GetDateTime(reader.GetOrdinal("deliveryDate"));
                                int shippedFrom = reader.GetInt32(reader.GetOrdinal("shipped_from"));
                                int shippedTo = reader.GetInt32(reader.GetOrdinal("shipped_to"));
                                string status = reader.GetString(reader.GetOrdinal("status"));

                                AddressDataModel origin = _addressAccessor.GetAddress(shippedFrom);
                                AddressDataModel destination = _addressAccessor.GetAddress(shippedTo);

                                OrderDataModel o = new OrderDataModel(orderId, packageId, shipDate, deliveryDate, accountId,
                                    origin, destination, status);
                                orderList.Add(o);
                            }
                        }

                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
            return orderList;
        }
        
        public void UpdateOrderStatus(int orderId, string status)
        {
            string query = "UPDATE [Order] SET status = @Status WHERE orderId = @OrderId";
            using (_connection)
            {
                try
                {
                    _connection.Open();
                    using (SqlCommand command = new SqlCommand(query,_connection))
                    {
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
        }
    }
}
