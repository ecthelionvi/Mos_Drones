using Accessors.DBModels;
using Accessors.Accessors;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class GetDroneAccessorTests
    {
        [TestMethod]
        public void ValidGetDrone()
        {
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
            DroneDataModel invalidDrone = DroneAccessor.GetDrone(-1);
            Assert.IsNull(invalidDrone);
        }
    }
}
