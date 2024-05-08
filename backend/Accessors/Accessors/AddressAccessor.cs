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
                        double latitude = reader.GetDouble(reader.GetOrdinal("latitude"));
                        double longitude = reader.GetDouble(reader.GetOrdinal("longitude"));

                        Coordinate coordinate = new Coordinate(latitude, longitude);
                        AddressDataModel a = new AddressDataModel(addressId, city, state, zip, addressLine, coordinate);
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
                    double latitude = reader.GetDouble(reader.GetOrdinal("latitude"));
                    double longitude = reader.GetDouble(reader.GetOrdinal("longitude"));

                    Coordinate coordinate = new Coordinate(latitude, longitude);
                    address = new AddressDataModel(addressId, city, state, zip, addressLine, coordinate);
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
        /// This method checks if the given Address instance already exists in the database and inserts a new Address record if it doesn't. 
        /// It returns the address id of the newly inserted record or the existing Address record.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public async Task<int> InsertAddress(AddressDataModel a)
        {
            if(a.Coordinates == null)
            {
                OpenRouteAccessor openRouteAccessor = new OpenRouteAccessor();
                a.Coordinates = await openRouteAccessor.GetCoordinatesAsync(a);
            }
            
            string selectQuery = @"SELECT addressId FROM Address WHERE city = @City 
                           AND state = @State AND zip = @Zip AND address_line = @AddressLine
                           AND latitude = @Latitude AND longitude = @Longitude";

            string insertQuery = @"INSERT INTO Address (city, state, zip, address_line, latitude, longitude) 
                             VALUES (@City, @State, @Zip, @AddressLine, @Latitude, @Longitude); SELECT SCOPE_IDENTITY();";

            string city = a.City;
            string state = a.State;
            string zip = a.ZipCode;
            string addressLine = a.AddressLine;
            double latitude = a.Coordinates.Latitude;
            double longitude = a.Coordinates.Longitude;
            
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
                selectCommand.Parameters.AddWithValue("@Latitude", latitude);
                selectCommand.Parameters.AddWithValue("@Longitude", longitude);

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
                    insertCommand.Parameters.AddWithValue("@Latitude", latitude);
                    insertCommand.Parameters.AddWithValue("@Longitude", longitude);

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
