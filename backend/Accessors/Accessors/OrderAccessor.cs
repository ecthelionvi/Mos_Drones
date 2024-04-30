using System.Data.SqlClient;
using System.Security.Principal;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    //TODO: ADD SUPPORT FOR NULL in insertOrder
    public class OrderAccessor : IOrderAccessor
    {
        /// <summary>
        /// Method to return an Order instance loaded from the database corresponding
        /// to the given orderId.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static OrderDataModel GetOrderWithOrderId(int orderId)
        {
            OrderDataModel order = null;
            AccountDataModel account = null;
            AddressDataModel origin = null;
            AddressDataModel destination = null;

            string query = "SELECT * FROM [Order] WHERE orderId = @OrderId";

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
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

                    account = AccountAccessor.GetAccountWithAccountId(accountId);
                    origin = AddressAccessor.GetAddress(shippedFrom);
                    destination = AddressAccessor.GetAddress(shippedTo);

                    order = new OrderDataModel(orderId, packageId, shipDate, deliveryDate, accountId, origin,
                        destination);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return order;
        }

        /// <summary>
        /// Method to return an Order instance loaded from the database corresponding
        /// to the given packageId string.
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public static OrderDataModel GetOrderWithPackageId(string packageId)
        {
            OrderDataModel order = null;
            AccountDataModel account = null;
            AddressDataModel origin = null;
            AddressDataModel destination = null;

            string query = "SELECT * FROM [Order] WHERE packageId = @PackageId";

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
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

                    origin = AddressAccessor.GetAddress(shippedFrom);
                    destination = AddressAccessor.GetAddress(shippedTo);

                    order = new OrderDataModel(orderId, packageId, shipDate, deliveryDate, accountId, origin,
                        destination);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return order;
        }

        /// <summary>
        /// Method to return all Order instances loaded from the database 
        /// that are associated with a specific Account with the given email,
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        // public static List<OrderDataModel> GetOrderListWithEmail(string email)
        // {
        //     List<OrderDataModel> orderList = new List<OrderDataModel>();
        //     string query =
        //         "SELECT o.* FROM [Order] o JOIN [Account] a ON o.accountId = a.accountId WHERE a.email = @Email";
        //
        //     SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();
        //
        //     try
        //     {
        //         connection.Open();
        //         SqlCommand command = new SqlCommand(query, connection);
        //         command.Parameters.AddWithValue("@Email", email);
        //         SqlDataReader reader = command.ExecuteReader();
        //         if (reader.HasRows)
        //         {
        //             while (reader.Read())
        //             {
        //                 int orderId = reader.GetInt32(reader.GetOrdinal("orderId"));
        //                 string packageId = reader.GetString(reader.GetOrdinal("packageId"));
        //                 DateTime shipDate = reader.GetDateTime(reader.GetOrdinal("ship_date"));
        //                 DateTime deliveryDate = reader.GetDateTime(reader.GetOrdinal("deliveryDate"));
        //                 int shippedFrom = reader.GetInt32(reader.GetOrdinal("shipped_from"));
        //                 int shippedTo = reader.GetInt32(reader.GetOrdinal("shipped_to"));
        //
        //                 AccountDataModel account = AccountAccessor.GetAccountWithEmail(email);
        //                 AddressDataModel origin = AddressAccessor.GetAddress(shippedFrom);
        //                 AddressDataModel destination = AddressAccessor.GetAddress(shippedTo);
        //
        //                 OrderDataModel o = new OrderDataModel(orderId, packageId, shipDate, deliveryDate, account,
        //                     origin, destination);
        //                 orderList.Add(o);
        //
        //             }
        //         }
        //
        //         reader.Close();
        //     }
        //     catch (SqlException ex)
        //     {
        //         Console.WriteLine($"SQL Exception: {ex.Message}");
        //     }
        //     finally
        //     {
        //         connection.Close();
        //     }
        //
        //     return orderList;
        // }

        /// <summary>
        /// Method to return all Order instances loaded from the database 
        /// that are associated with a specific Account with the given accountId,
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public static List<OrderDataModel> GetOrderListWithAccountId(int accountId)
        {
            List<OrderDataModel> orderList = new List<OrderDataModel>();
            string query =
                "SELECT o.* FROM [Order] o JOIN [Account] a ON o.accountId = a.accountId WHERE o.accountId = @AccountId";

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
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
                        
                        AddressDataModel origin = AddressAccessor.GetAddress(shippedFrom);
                        AddressDataModel destination = AddressAccessor.GetAddress(shippedTo);

                        OrderDataModel o = new OrderDataModel(orderId, packageId, shipDate, deliveryDate, accountId,
                            origin, destination);
                        orderList.Add(o);
                    }
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return orderList;
        }
        
        /// <summary>
        /// This method inserts a new Order record into the database. It generates a
        /// sixteen character string for the packageId and sets the ship date to the current date/time.
        /// </summary>
        /// <param name="accountEmail"></param>
        /// <param name="originCity"></param>
        /// <param name="originState"></param>
        /// <param name="originZip"></param>
        /// <param name="originAddressLine"></param>
        /// <param name="destCity"></param>
        /// <param name="destState"></param>
        /// <param name="destZip"></param>
        /// <param name="destAddressLine"></param>
        /// <returns></returns>
        public static int InsertOrder(OrderDataModel order)
        {
            string packageId = Guid.NewGuid().ToString("N").Substring(0, 16);
            DateTime shipDate = DateTime.Now;
            AccountDataModel orderAccount = AccountAccessor.GetAccountWithAccountId(order.AccountId);

            string selectQuery = @"SELECT accountId FROM Account WHERE email = @Email";

            string insertQuery =
                @"INSERT INTO [Order] (packageId, ship_date, deliveryDate, accountId, shipped_from, shipped_to) 
                                   VALUES (@PackageId, @ShipDate, @DeliveryDate, @AccountId, @ShippedFrom, @ShippedTo); SELECT SCOPE_IDENTITY();";

            int orderId = -1;

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();

                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@Email", orderAccount.Email);

                object account = selectCommand.ExecuteScalar();
                int accountId = Convert.ToInt32(account);

                int originId = AddressAccessor.InsertAddress(order.ShippedFrom.City, order.ShippedFrom.State,
                    order.ShippedFrom.ZipCode, order.ShippedFrom.AddressLine);
                int destinationId = AddressAccessor.InsertAddress(order.ShippedTo.City, order.ShippedTo.State,
                    order.ShippedTo.ZipCode, order.ShippedTo.AddressLine);

                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@PackageId", packageId);
                insertCommand.Parameters.AddWithValue("@ShipDate", shipDate);
                insertCommand.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
                insertCommand.Parameters.AddWithValue("@AccountId", accountId);
                insertCommand.Parameters.AddWithValue("@ShippedFrom", originId);
                insertCommand.Parameters.AddWithValue("@ShippedTo", destinationId);

                // Insert the record and get its id
                object orderResult = insertCommand.ExecuteScalar();
                orderId = Convert.ToInt32(orderResult);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return orderId;
        }
    }
}
