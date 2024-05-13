using System.Data.SqlClient;
using Accessors.Depot;
using Accessors.Depot.Models;
using Accessors.Drone;
using Accessors.Drone.Models;
using Accessors.Order;
using Accessors.Order.Models;

namespace Accessors.Drone
{
    public class DroneAccessor : IDroneAccessor
    {
        private readonly string _connection;
        private readonly IOrderAccessor _orderAccessor;
        private readonly IDepotAccessor _depotAccessor;

        public DroneAccessor(string connection, IOrderAccessor orderAccessor, IDepotAccessor depotAccessor)
        {
            _connection = connection;
            _orderAccessor = orderAccessor;
            _depotAccessor = depotAccessor;
        }
        public DroneDataModel GetDrone(int droneId)
        {
            DroneDataModel drone = new DroneDataModel();

            string query = "Select * from [Drone] where droneId = @DroneId";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

                            OrderDataModel? droneOrder = null;
                            
                            if (orderId.HasValue)
                            {
                                droneOrder = _orderAccessor.GetOrderWithOrderId(orderId.Value);
                            }

                            int? depotId = null; // Nullable depotId
                            if (!reader.IsDBNull(reader.GetOrdinal("depotId")))
                            {
                                depotId = reader.GetInt32(reader.GetOrdinal("depotId"));
                            }

                            DepotDataModel? currDepot = null;
                            
                            if (depotId.HasValue)
                            {
                                currDepot = _depotAccessor.GetDepotWithDepotId(depotId.Value);
                            }

                            drone = new DroneDataModel(droneId, status, droneOrder, currDepot);
                        }

                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
            return drone;
        }
        
        public List<DroneDataModel> GetDroneList()
        {
            List<DroneDataModel> droneList = new List<DroneDataModel>();
            string query = "SELECT * FROM Drone";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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
                                    droneOrder = _orderAccessor.GetOrderWithOrderId(orderId.Value);
                                }

                                int? depotId = null; // Nullable depotId
                                if (!reader.IsDBNull(reader.GetOrdinal("depotId")))
                                {
                                    depotId = reader.GetInt32(reader.GetOrdinal("depotId"));
                                }

                                if (depotId.HasValue)
                                {
                                    currDepot = _depotAccessor.GetDepotWithDepotId(depotId.Value);
                                }

                                DroneDataModel d = new DroneDataModel(droneId, transitStatus, droneOrder, currDepot);
                                droneList.Add(d);
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
            return droneList;
        }
        
        public void UpdateDroneStatus(int droneId, string newStatus, int? orderId)
        {
            string query = "UPDATE Drone SET transit_status = @NewStatus, orderId = @OrderId WHERE droneId = @DroneId";;

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewStatus", newStatus);
                        command.Parameters.AddWithValue("@DroneId", droneId);
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
        }
    }
}
