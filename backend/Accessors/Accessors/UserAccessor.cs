using System.Data.SqlClient;
using Managers.Models;

namespace Accessors.Accessors
{
    public class UserAccessor
    {
        public static User GetUser(int userId)
        {
            User user = null;
            Account userAccount = null;

            string query = "SELECT * FROM [User] WHERE userId = @UserId";

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    bool isAdmin = reader.GetBoolean(reader.GetOrdinal("isAdmin"));
                    int accountId = reader.GetInt32(reader.GetOrdinal("accountId"));

                    userAccount = AccountAccessor.GetAccountWithAccountId(accountId);

                    user = new User(userId, isAdmin, userAccount);
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

            return user;
        }
    }
}
