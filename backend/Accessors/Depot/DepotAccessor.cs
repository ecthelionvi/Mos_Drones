using System.Data.SqlClient;
using Accessors.Address;
using Accessors.Address.Models;
using Accessors.Depot.Models;

namespace Accessors.Depot
{
    public class DepotAccessor : IDepotAccessor
    {
        private readonly SqlConnection _connection;
        private readonly IAddressAccessor _addressAccessor;

        public DepotAccessor(SqlConnection connection, IAddressAccessor addressAccessor)
        {
            _connection = connection;
            _addressAccessor = addressAccessor;
        }
        public DepotDataModel GetDepotWithDepotId(int depotId)
        {
            DepotDataModel depot = new DepotDataModel();

            string query = "SELECT * FROM Depot WHERE depotId = @DepotId";

            using (_connection)
            {
                try
                {
                    _connection.Open();
                    using (SqlCommand command = new SqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@DepotId", depotId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows && reader.Read())
                        {
                            int addressId = reader.GetInt32(reader.GetOrdinal("addressId"));

                            AddressDataModel depotAddress = _addressAccessor.GetAddress(addressId);

                            depot = new DepotDataModel(depotId, depotAddress);
                        }

                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
            }
            return depot;
        }

        public List<DepotDataModel> GetDepotList()
        {
            List<DepotDataModel> depotList = new List<DepotDataModel>();

            string query = "SELECT * FROM Depot";

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
                                int depotId = reader.GetInt32(reader.GetOrdinal("depotId"));
                                int addressId = reader.GetInt32(reader.GetOrdinal("addressId"));

                                AddressDataModel depotAddress = _addressAccessor.GetAddress(addressId);

                                DepotDataModel depot = new DepotDataModel(depotId, depotAddress);
                                depotList.Add(depot);
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
            return depotList;
        }
    }
}
