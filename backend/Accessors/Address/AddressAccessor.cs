using System.Data.SqlClient;
using Accessors.Address.Models;
using Accessors.API.OpenRoute;

namespace Accessors.Address
{
    public class AddressAccessor : IAddressAccessor
    {
        private readonly SqlConnection _connection;

        public AddressAccessor(string connection)
        {
            _connection = new SqlConnection(connection);
        }
        public List<AddressDataModel> GetAddressList()
        {
            List<AddressDataModel> addressList = new List<AddressDataModel>();
            string query = "SELECT * FROM Address";

            using (_connection)
            {
                try
                {
                    _connection.Open();
                    using (SqlCommand command = new SqlCommand(query, _connection))
                    {
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
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
            return addressList;
        }
        
        public AddressDataModel GetAddress(int addressId)
        {
            AddressDataModel address = new AddressDataModel();
            string query = "SELECT * FROM Address WHERE addressId = @AddressId";

            using (_connection)
            {
                try
                {
                    _connection.Open();
                    using (SqlCommand command = new SqlCommand(query, _connection))
                    {
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
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
            return address;
        }
        
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

            using (_connection)
            {
                try
                {
                    _connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, _connection))
                    {
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
                        }
                        else
                        {
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, _connection))
                            {
                                insertCommand.Parameters.AddWithValue("@City", city);
                                insertCommand.Parameters.AddWithValue("@State", state);
                                insertCommand.Parameters.AddWithValue("@Zip", zip);
                                insertCommand.Parameters.AddWithValue("@AddressLine", addressLine);
                                insertCommand.Parameters.AddWithValue("@Latitude", latitude);
                                insertCommand.Parameters.AddWithValue("@Longitude", longitude);

                                // Insert the record and get its id
                                address = insertCommand.ExecuteScalar();
                                addressId = Convert.ToInt32(address);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
            return addressId;
        }
    }
}
