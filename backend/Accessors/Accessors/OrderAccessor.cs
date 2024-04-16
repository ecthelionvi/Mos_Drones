using System.Data.SqlClient;
using System.Security.Principal;

namespace Accessors.Accessors
{
    public class OrderAccessor
    {
        public static Order GetOrderWithOrderId(int orderId)
        {
            Order order = null;
            Account account = null;
            Address origin = null;
            Address destination = null;

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
                    int accountId = reader.GetInt32(reader.GetOrdinal("accountId"));
                    int shippedFrom = reader.GetInt32(reader.GetOrdinal("shipped_from"));
                    int shippedTo = reader.GetInt32(reader.GetOrdinal("shipped_to"));

                    account = AccountAccessor.GetAccountWithAccountId(accountId);
                    origin = AddressAccessor.GetAddress(shippedFrom);
                    destination = AddressAccessor.GetAddress(shippedTo);

                    order = new Order(orderId, packageId, shipDate, account, origin, destination);
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

        public static Order GetOrderWithPackageId(string packageId)
        {
            Order order = null;
            Account account = null;
            Address origin = null;
            Address destination = null;

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
                    int accountId = reader.GetInt32(reader.GetOrdinal("accountId"));
                    int shippedFrom = reader.GetInt32(reader.GetOrdinal("shipped_from"));
                    int shippedTo = reader.GetInt32(reader.GetOrdinal("shipped_to"));

                    account = AccountAccessor.GetAccountWithAccountId(accountId);
                    origin = AddressAccessor.GetAddress(shippedFrom);
                    destination = AddressAccessor.GetAddress(shippedTo);

                    order = new Order(orderId, packageId, shipDate, account, origin, destination);
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

        public static List<Order> GetOrderListWithEmail(string email)
        {
            List<Order> orderList = new List<Order>();
            string query = "SELECT o.* FROM [Order] o JOIN [Account] a ON o.accountId = a.accountId WHERE a.email = @Email";

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int orderId = reader.GetInt32(reader.GetOrdinal("orderId"));
                        string packageId = reader.GetString(reader.GetOrdinal("packageId"));
                        DateTime shipDate = reader.GetDateTime(reader.GetOrdinal("ship_date"));
                        int shippedFrom = reader.GetInt32(reader.GetOrdinal("shipped_from"));
                        int shippedTo = reader.GetInt32(reader.GetOrdinal("shipped_to"));

                        Account account = AccountAccessor.GetAccountWithEmail(email);
                        Address origin = AddressAccessor.GetAddress(shippedFrom);
                        Address destination = AddressAccessor.GetAddress(shippedTo);

                        Order o = new Order(orderId, packageId, shipDate, account, origin, destination);
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
    }
}
