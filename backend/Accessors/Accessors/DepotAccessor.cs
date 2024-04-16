﻿using System.Data.SqlClient;
using System.Security.Principal;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    public class DepotAccessor
    {
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
    }
}