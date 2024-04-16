using System.Data.SqlClient;
using System.Net;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    public class AccountAccessor
    {
        public static AccountDataModel GetAccountWithAccountId(int accountId)
        {
            AccountDataModel account = null;
            AddressDataModel accountAddress = null;

            string query = "SELECT * FROM Account WHERE accountId = @AccountId";

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AccountId", accountId);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    string firstName = reader.GetString(reader.GetOrdinal("first_name"));
                    string lastName = reader.GetString(reader.GetOrdinal("last_name"));
                    string email = reader.GetString(reader.GetOrdinal("email"));
                    string password = reader.GetString(reader.GetOrdinal("password"));
                    int addressId = reader.GetInt32(reader.GetOrdinal("addressId"));
                    bool isAdmin = reader.GetBoolean(reader.GetOrdinal("isAdmin"));

                    accountAddress = AddressAccessor.GetAddress(addressId);

                    account = new AccountDataModel(accountId, firstName, lastName, email, password, accountAddress,isAdmin);
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
        public static AccountDataModel GetAccountWithEmail(string email)
        {
            AccountDataModel account = null;
            AddressDataModel accountAddress = null;

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
                    bool isAdmin = reader.GetBoolean(reader.GetOrdinal("isAdmin"));

                    accountAddress = AddressAccessor.GetAddress(addressId);

                    account = new AccountDataModel(accountId, firstName, lastName, email, password, accountAddress, isAdmin);
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
