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
            DroneDataModel expectedDrone = new DroneDataModel(1, "Free", null, null);
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
