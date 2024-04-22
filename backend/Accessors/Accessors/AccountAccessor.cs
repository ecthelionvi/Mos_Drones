using System.Data.SqlClient;
using System.Net;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    public class AccountAccessor
    {
        /// <summary>
        /// Method to return an Account instance loaded from the database 
        /// corresponding to the given accountId.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to return an Account instance loaded from the database with the
        /// email associated with the account.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method checks if the Account record with the given parameters already
        /// exists in the database and inserts a new Account record if it doesn't.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="addressLine"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        public static int InsertAccount(string firstName, string lastName, string email, string password, string city, string state, string zip, string addressLine, bool isAdmin)
        {
            string selectQuery = @"SELECT accountId FROM Account WHERE email = @Email";

            string insertQuery = @"INSERT INTO Account (first_name, last_name, email, password, addressId, isAdmin) 
                             VALUES (@FirstName, @LastName, @Email, @Password, @AddressId, @IsAdmin); SELECT SCOPE_IDENTITY();";

            int accountId = -1;

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@Email", email);

                object account = selectCommand.ExecuteScalar();

                if (account != null && account != DBNull.Value) // Address already exists in database
                {
                    accountId = Convert.ToInt32(account);
                    //Console.WriteLine("Account already exists in the database.");
                }
                else
                {
                    int addressId = AddressAccessor.InsertAddress(city, state, zip, addressLine);
                    
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@FirstName", firstName);
                    insertCommand.Parameters.AddWithValue("@LastName", lastName);
                    insertCommand.Parameters.AddWithValue("@Email", email);
                    insertCommand.Parameters.AddWithValue("@Password", password);
                    insertCommand.Parameters.AddWithValue("@AddressId", addressId);
                    insertCommand.Parameters.AddWithValue("@IsAdmin", isAdmin);

                    // Insert the record and get its id
                    account = insertCommand.ExecuteScalar();
                    accountId = Convert.ToInt32(account);
                    //Console.WriteLine("Account inserted successfully.");
                    //Console.WriteLine("The addressId for the inserted account is " + addressId);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return accountId;
        }
    }
}
