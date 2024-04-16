using System.Data.SqlClient;
using System.Data.SqlTypes;
using Accessors.DBModels;
using Microsoft.AspNetCore.Components.Web;

namespace Accessors.Accessors
{
    public class DroneAccessor
    {
        public static DroneDataModel GetDrone(int droneId)
        {
            DroneDataModel drone = null;
            OrderDataModel droneOrder = null;
            DepotDataModel currDepot = null;

            string query = "Select * from [Drone] where droneId = @DroneId";

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DroneId", droneId);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    string status = reader.GetString(reader.GetOrdinal("transit_status"));
                    int orderId = reader.GetInt32(reader.GetOrdinal("orderId"));
                    int? depotId = null; // Nullable depotId
                    if (!reader.IsDBNull(reader.GetOrdinal("depotId")))
                    {
                        depotId = reader.GetInt32(reader.GetOrdinal("depotId"));
                    }

                    if (depotId.HasValue)
                    {
                        currDepot = DepotAccessor.GetDepotWithDepotId(depotId.Value);
                    }

                    droneOrder = OrderAccessor.GetOrderWithOrderId(orderId);

                    drone = new DroneDataModel(droneId, status, droneOrder, currDepot);
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

            return drone;
        }
        
        public static List<DroneDataModel> GetDroneList()
        {
            List<DroneDataModel> droneList = new List<DroneDataModel>();
            string query = "SELECT * FROM Drone";

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
                        DepotDataModel currDepot = null;

                        int droneId = reader.GetInt32(reader.GetOrdinal("droneId"));
                        string transitStatus = reader.GetString(reader.GetOrdinal("transit_status"));
                        int orderId = reader.GetInt32(reader.GetOrdinal("orderId"));
                        int? depotId = null; // Nullable depotId
                        if (!reader.IsDBNull(reader.GetOrdinal("depotId")))
                        {
                            depotId = reader.GetInt32(reader.GetOrdinal("depotId"));
                        }

                        if (depotId.HasValue)
                        {
                            currDepot = DepotAccessor.GetDepotWithDepotId(depotId.Value);
                        }

                        OrderDataModel droneOrder = OrderAccessor.GetOrderWithOrderId(orderId);

                        DroneDataModel d = new DroneDataModel(droneId, transitStatus, droneOrder, currDepot);
                        droneList.Add(d);
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
            return droneList;
        }
    }
}
