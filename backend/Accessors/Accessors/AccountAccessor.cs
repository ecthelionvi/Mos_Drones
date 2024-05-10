using System.Data.SqlClient;
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

            using (SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

                            account = new AccountDataModel(accountId, firstName, lastName, email, password, accountAddress, isAdmin);
                        }

                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
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

            using (SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
            return account;
        }

        /// <summary>
        /// This method checks if the given Account instance already exists in the database and inserts a new Account record if it doesn't.
        /// It returns the account id of the newly inserted record or the existing Account record.
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        public async Task<int> InsertAccount(AccountDataModel acc)
        {
            string selectQuery = @"SELECT accountId FROM Account WHERE email = @Email";

            string insertQuery = @"INSERT INTO Account (first_name, last_name, email, password, addressId, isAdmin) 
                             VALUES (@FirstName, @LastName, @Email, @Password, @AddressId, @IsAdmin); SELECT SCOPE_IDENTITY();";

            int accountId = -1;

            using (SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@Email", acc.Email);

                        object account = selectCommand.ExecuteScalar();

                        if (account != null && account != DBNull.Value) // Address already exists in database
                        {
                            accountId = Convert.ToInt32(account);
                        }
                        else
                        {
                            AddressAccessor addressAccessor = new AddressAccessor();
                            int addressId = await addressAccessor.InsertAddress(acc.AccountAddress);

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@FirstName", acc.FirstName);
                                insertCommand.Parameters.AddWithValue("@LastName", acc.LastName);
                                insertCommand.Parameters.AddWithValue("@Email", acc.Email);
                                insertCommand.Parameters.AddWithValue("@Password", acc.Password);
                                insertCommand.Parameters.AddWithValue("@AddressId", addressId);
                                insertCommand.Parameters.AddWithValue("@IsAdmin", acc.IsAdmin);

                                // Insert the record and get its id
                                account = insertCommand.ExecuteScalar();
                                accountId = Convert.ToInt32(account);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
            return accountId;
        }
    }
}
