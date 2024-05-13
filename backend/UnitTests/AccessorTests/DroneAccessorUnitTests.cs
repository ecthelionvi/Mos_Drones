using Accessors.Account;
using Accessors.Address;
using Accessors.Address.Models;
using Accessors.Depot;
using Accessors.Depot.Models;
using Accessors.Drone;
using Accessors.Drone.Models;
using Accessors.Order;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class GetDroneAccessorTests
    {
        [TestMethod]
        public void ValidGetDrone()
        {
            string connection =
                "Server=localhost,1433;Database=master;User Id=SA;Password=MyStrongPassword123;Integrated Security=False;";
            AddressAccessor addressAccessor =
                new AddressAccessor(
                    connection);
            AccountAccessor account = new AccountAccessor(connection, addressAccessor);
            
            OrderAccessor orderAccessor = new OrderAccessor(connection, account, addressAccessor);
            
            DepotAccessor DepotAccessor = new DepotAccessor(connection, addressAccessor);
            DroneAccessor DroneAccessor = new DroneAccessor(connection, orderAccessor, DepotAccessor);
            
            Coordinate coord = new Coordinate(40.911152, -97.101418);
            AddressDataModel address = new AddressDataModel(6, "Seward", "Nebraska", "68434", "434 North 8th Street", coord);
            DepotDataModel depot = new DepotDataModel(1, address);
            DroneDataModel expectedDrone = new DroneDataModel(1, "Free", null, depot);
            DroneDataModel actualDrone = DroneAccessor.GetDrone(1);
            Assert.AreEqual(expectedDrone, actualDrone);
        }

        [TestMethod]
        public void InvalidGetDrone()
        {
            string connection =
                "Server=localhost,1433;Database=master;User Id=SA;Password=MyStrongPassword123;Integrated Security=False;";
            AddressAccessor addressAccessor =
                new AddressAccessor(
                    connection);
            AccountAccessor account = new AccountAccessor(connection, addressAccessor);
            OrderAccessor orderAccessor = new OrderAccessor(connection, account, addressAccessor);
            DepotAccessor DepotAccessor = new DepotAccessor(connection, addressAccessor);
            DroneAccessor DroneAccessor = new DroneAccessor(connection, orderAccessor, DepotAccessor);
            
            DroneDataModel invalidDrone = DroneAccessor.GetDrone(-1);
            Assert.IsNull(invalidDrone);
        }
    }
}
