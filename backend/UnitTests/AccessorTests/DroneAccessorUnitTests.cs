using Accessors.DBModels;
using Accessors.Accessors;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class GetDroneAccessorTest
    {
        [TestMethod]
        public void ValidGetDrone()
        {
            DateTime shipDate = new DateTime(2024, 04, 14, 10, 30, 0, 0);
            DateTime deliveryDate = new DateTime(2024, 04, 17, 15, 44, 0, 0);
            AddressDataModel accountAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street");
            AccountDataModel account = new AccountDataModel(1, "Alfred", "Van Arsdall", "avanarsdall0@cocolog-nifty.com", "uI7lq}{e0WU", accountAddress, true);
            AddressDataModel shippedFrom = accountAddress;
            AddressDataModel shippedTo = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street");
            OrderDataModel order = new OrderDataModel(1, "4829170638572946", shipDate, deliveryDate, account, shippedFrom, shippedTo);

            AddressDataModel depotAddress = new AddressDataModel(3, "Lincoln", "Nebraska", "68516", "9876 Pine Lake Road");
            DepotDataModel currentDepot = new DepotDataModel(1, depotAddress);

            DroneDataModel expectedDrone = new DroneDataModel(1, "At Depot", order, currentDepot); ;
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

    [TestClass]
    public class GetDroneListTests
    {
        [TestMethod]
        public void ValidGetDroneList()
        {
            DateTime shipDate = new DateTime(2024, 04, 14, 10, 30, 0, 0);
            DateTime deliveryDate = new DateTime(2024, 04, 17, 15, 44, 0, 0);
            AddressDataModel accountAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street");
            AccountDataModel account = new AccountDataModel(1, "Alfred", "Van Arsdall", "avanarsdall0@cocolog-nifty.com", "uI7lq}{e0WU", accountAddress, true);
            AddressDataModel shippedFrom = accountAddress;
            AddressDataModel shippedTo = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street");
            OrderDataModel order = new OrderDataModel(1, "4829170638572946", shipDate, deliveryDate, account, shippedFrom, shippedTo);

            AddressDataModel depotAddress = new AddressDataModel(3, "Lincoln", "Nebraska", "68516", "9876 Pine Lake Road");
            DepotDataModel currentDepot = new DepotDataModel(1, depotAddress);

            DroneDataModel drone1 = new DroneDataModel(1, "At Depot", order, currentDepot); ;

            DateTime shipDate2 = new DateTime(2024, 04, 01, 17, 12, 0, 0);
            DateTime deliveryDate2 = new DateTime(2024, 04, 05, 08, 15, 0, 0);
            AddressDataModel accountAddress2 = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street");
            AccountDataModel account2 = new AccountDataModel(2, "Beltran", "Lillie", "blillie1@imdb.com", "hC7S>lx+N7a(?2>k", accountAddress2, false);
            AddressDataModel shippedFrom2 = accountAddress;
            AddressDataModel shippedTo2 = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street");
            OrderDataModel order2 = new OrderDataModel(2, "7294061538206194", shipDate2, deliveryDate2, account2, shippedFrom2, shippedTo2);

            DroneDataModel drone2 = new DroneDataModel(2, "Delivered", order2, null);

            List<DroneDataModel> expectedDroneList = new List<DroneDataModel>();
            expectedDroneList.Add(drone1);
            expectedDroneList.Add(drone2);

            List<DroneDataModel> actualDroneList = DroneAccessor.GetDroneList();
            CollectionAssert.AreEquivalent(actualDroneList, expectedDroneList);
        }
    }
}
