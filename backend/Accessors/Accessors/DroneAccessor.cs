using System.Data.SqlClient;
using System.Data.SqlTypes;
using Accessors.DBModels;
using Microsoft.AspNetCore.Components.Web;

namespace Accessors.Accessors
{
    public class DroneAccessor
    {
        /// <summary>
        /// Method to return a Drone instance loaded from the database corresponding
        /// to the given droneId.
        /// </summary>
        /// <param name="droneId"></param>
        /// <returns></returns>
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
                    int? orderId = null;
                    if (!reader.IsDBNull(reader.GetOrdinal("orderId")))
                    {
                        orderId = reader.GetInt32(reader.GetOrdinal("orderId"));
                    }
                    if (orderId.HasValue)
                    {
                        droneOrder = OrderAccessor.GetOrderWithOrderId(orderId.Value);
                    }

                    int? depotId = null; // Nullable depotId
                    if (!reader.IsDBNull(reader.GetOrdinal("depotId")))
                    {
                        depotId = reader.GetInt32(reader.GetOrdinal("depotId"));
                    }

                    if (depotId.HasValue)
                    {
                        currDepot = DepotAccessor.GetDepotWithDepotId(depotId.Value);
                    }

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

        /// <summary>
        /// Method to return a list of all Drone instances from the database.
        /// </summary>
        /// <returns></returns>
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
                        OrderDataModel droneOrder = null;

                        int droneId = reader.GetInt32(reader.GetOrdinal("droneId"));
                        string transitStatus = reader.GetString(reader.GetOrdinal("transit_status"));
                        int? orderId = null;
                        if (!reader.IsDBNull(reader.GetOrdinal("orderId")))
                        {
                            orderId = reader.GetInt32(reader.GetOrdinal("orderId"));
                        }
                        if (orderId.HasValue)
                        {
                            droneOrder = OrderAccessor.GetOrderWithOrderId(orderId.Value);
                        }

                        int? depotId = null; // Nullable depotId
                        if (!reader.IsDBNull(reader.GetOrdinal("depotId")))
                        {
                            depotId = reader.GetInt32(reader.GetOrdinal("depotId"));
                        }

                        if (depotId.HasValue)
                        {
                            currDepot = DepotAccessor.GetDepotWithDepotId(depotId.Value);
                        }

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
