using Accessors.DBModels;
using Accessors.Accessors;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class GetDepotWithDepotIdAccessorTests
    {
        [TestMethod]
        public void ValidGetDepotWithDepotId()
        {
            Coordinate coord = new Coordinate(40.911152, -97.101418);
            AddressDataModel depotAddress = new AddressDataModel(6, "Seward", "Nebraska", "68434", "434 North 8th Street", coord);
            DepotDataModel expectedDepot = new DepotDataModel(1, depotAddress);

            DepotDataModel actualDepot = DepotAccessor.GetDepotWithDepotId(1);
            Assert.AreEqual(expectedDepot, actualDepot);
        }

        [TestMethod]
        public void InvalidGetDepotWithDepotId()
        {
            DepotDataModel depot = DepotAccessor.GetDepotWithDepotId(-1);
            Assert.IsNull(depot);
        }
    }
}
