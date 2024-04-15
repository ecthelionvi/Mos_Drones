using System.Data.SqlClient;
using System.Data.SqlTypes;
using Managers.Models;
using Microsoft.AspNetCore.Components.Web;

namespace Accessors
    public class DroneAccessor
    {
        public static Drone GetDrone(int droneId)
        {
            Drone drone = null;

            string query = "Select * from [Drone] where droneId = @DroneId";

            SqlConnection connection = ConnectionAccessor.ConnectionAccessor.GetConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DroneId", droneId);
                SqlDataReader reader = commmand.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    string Status = reader.GetString(reader.GetOrdinal("Status"));
                    string Destination = reader.GetString(reader.GetOrdinal("Destination"));

                    drone = new Drone(droneId, Status, Destination);
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
    }

