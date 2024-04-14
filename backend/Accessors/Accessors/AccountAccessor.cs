using System.Data.SqlClient;
using System.Net;
using Managers.Models;

namespace Accessors.Accessors
{
    public class AccountAccessor
    {
        public static Account GetAccountWithEmail(string email)
        {
            Account account = null;
            Address accountAddress = null;

            string query = "SELECT * FROM Account WHERE email = @Email";

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    int accountId = reader.GetInt32(reader.GetOrdinal("accountId"));
                    string firstName = reader.GetString(reader.GetOrdinal("first_name"));
                    string lastName = reader.GetString(reader.GetOrdinal("last_name"));
                    string password = reader.GetString(reader.GetOrdinal("password"));
                    int addressId = reader.GetInt32(reader.GetOrdinal("addressId"));

                    accountAddress = AddressAccessor.GetAddress(addressId);

                    account = new Account(accountId, firstName, lastName, email, password, accountAddress);
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

            return account;
        }
    }
}
