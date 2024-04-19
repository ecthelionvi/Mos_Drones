using System.Data.SqlClient;
using System.Collections.Generic;
using Accessors.ConnectionAccessor;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    public class AddressAccessor
    {
        /// <summary>
        /// Method to return all Address instances loaded from the database.
        /// </summary>
        /// <returns></returns>
        public static List<AddressDataModel> GetAddressList()
        {
            List<AddressDataModel> addressList = new List<AddressDataModel>();
            string query = "SELECT * FROM Address";

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int addressId = reader.GetInt32(reader.GetOrdinal("addressId"));
                        string city = reader.GetString(reader.GetOrdinal("city"));
                        string state = reader.GetString(reader.GetOrdinal("state"));
                        string zip = reader.GetString(reader.GetOrdinal("zip"));
                        string addressLine = reader.GetString(reader.GetOrdinal("address_line"));

                        AddressDataModel a = new AddressDataModel(addressId, city, state, zip, addressLine);
                        addressList.Add(a);

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
            return addressList;
        }

        /// <summary>
        /// Method to return an Address instance loaded from the database corresponding
        /// to the given addressId.
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public static AddressDataModel GetAddress(int addressId)
        {
            AddressDataModel address = null;
            string query = "SELECT * FROM Address WHERE addressId = @AddressId";

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AddressId", addressId);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    string city = reader.GetString(reader.GetOrdinal("city"));
                    string state = reader.GetString(reader.GetOrdinal("state"));
                    string zip = reader.GetString(reader.GetOrdinal("zip"));
                    string addressLine = reader.GetString(reader.GetOrdinal("address_line"));
                    
                    address = new AddressDataModel(addressId, city, state, zip, addressLine);
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
            return address;
        }

        /// <summary>
        /// This method checks if the Address record with the given parameters already
        /// exists in the database and inserts a new Address record if it doesn't.
        /// </summary>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="addressLine"></param>
        public static int InsertAddress(string city, string state, string zip, string addressLine)
        {
            string selectQuery = @"SELECT addressId FROM Address WHERE city = @City 
                           AND state = @State AND zip = @Zip AND address_line = @AddressLine";

            string insertQuery = @"INSERT INTO Address (city, state, zip, address_line) 
                             VALUES (@City, @State, @Zip, @AddressLine); SELECT SCOPE_IDENTITY();";

            int addressId = -1;

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@City", city);
                selectCommand.Parameters.AddWithValue("@State", state);
                selectCommand.Parameters.AddWithValue("@Zip", zip);
                selectCommand.Parameters.AddWithValue("@AddressLine", addressLine);

                object address = selectCommand.ExecuteScalar();

                if (address != null && address != DBNull.Value) // Address already exists in database
                {
                    addressId = Convert.ToInt32(address);
                    //Console.WriteLine("Address already exists in the database.");
                }
                else
                {
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@City", city);
                    insertCommand.Parameters.AddWithValue("@State", state);
                    insertCommand.Parameters.AddWithValue("@Zip", zip);
                    insertCommand.Parameters.AddWithValue("@AddressLine", addressLine);

                    // Insert the record and get its id
                    address = insertCommand.ExecuteScalar();
                    addressId = Convert.ToInt32(address);
                    //Console.WriteLine("Address inserted successfully.");
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

            return addressId;
        }
    }
}
