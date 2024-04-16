using System.Data.SqlClient;
using System.Collections.Generic;
using Accessors.ConnectionAccessor;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    public class AddressAccessor
    {
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
    }
}
