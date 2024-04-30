using System.Data.SqlClient;
using System.Security.Principal;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    public class DepotAccessor : IDepotAccessor
    {
        /// <summary>
        /// Method to return a Depot instance loaded from the database corresponding
        /// to the given depotId.
        /// </summary>
        /// <param name="depotId"></param>
        /// <returns></returns>
        public static DepotDataModel GetDepotWithDepotId(int depotId)
        {
            DepotDataModel depot = null;
            AddressDataModel depotAddress = null;

            string query = "SELECT * FROM Depot WHERE depotId = @DepotId";

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DepotId", depotId);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    int addressId = reader.GetInt32(reader.GetOrdinal("addressId"));

                    depotAddress = AddressAccessor.GetAddress(addressId);

                    depot = new DepotDataModel(depotId, depotAddress);
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

            return depot;
        }

        /// <summary>
        /// Method to return a list of all Depot instances loaded from the database.
        /// </summary>
        /// <returns></returns>
        public static List<DepotDataModel> GetDepotList()
        {
            List<DepotDataModel> depotList = new List<DepotDataModel>();

            string query = "SELECT * FROM Depot";

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
                        int depotId = reader.GetInt32(reader.GetOrdinal("depotId"));
                        int addressId = reader.GetInt32(reader.GetOrdinal("addressId"));

                        AddressDataModel depotAddress = AddressAccessor.GetAddress(addressId);

                        DepotDataModel depot = new DepotDataModel(depotId, depotAddress);
                        depotList.Add(depot);
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

            return depotList;
        }
    }
}
