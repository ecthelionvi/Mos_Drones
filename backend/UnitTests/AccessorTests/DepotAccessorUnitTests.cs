using Accessors.Account;
using Accessors.Address;
using Accessors.Address.Models;
using Accessors.Depot;
using Accessors.Depot.Models;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class GetDepotWithDepotIdAccessorTests
    {
        [TestMethod]
        public void ValidGetDepotWithDepotId()
        {
            string connection =
                "Server=localhost,1433;Database=master;User Id=SA;Password=MyStrongPassword123;Integrated Security=False;";
            AddressAccessor accessor =
                new AddressAccessor(
                    connection);
            
            DepotAccessor DepotAccessor = new DepotAccessor(connection, accessor);
            
            Coordinate coord = new Coordinate(40.911152, -97.101418);
            AddressDataModel depotAddress = new AddressDataModel(6, "Seward", "Nebraska", "68434", "434 North 8th Street", coord);
            DepotDataModel expectedDepot = new DepotDataModel(1, depotAddress);

            DepotDataModel actualDepot = DepotAccessor.GetDepotWithDepotId(1);
            Assert.AreEqual(expectedDepot, actualDepot);
        }

        [TestMethod]
        public void InvalidGetDepotWithDepotId()
        {
            string connection =
                "Server=localhost,1433;Database=master;User Id=SA;Password=MyStrongPassword123;Integrated Security=False;";
            AddressAccessor accessor =
                new AddressAccessor(
                    connection);
            
            DepotAccessor DepotAccessor = new DepotAccessor(connection, accessor);
            DepotDataModel depot = DepotAccessor.GetDepotWithDepotId(-1);
            Assert.IsNull(depot);
        }
    }
}
