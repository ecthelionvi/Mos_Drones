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
            AddressDataModel depotAddress = new AddressDataModel(3, "Lincoln", "Nebraska", "68516", "9876 Pine Lake Road");
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

    [TestClass]
    public class GetDepotListTests
    {
        [TestMethod]
        public void ValidGetDepotList()
        {
            AddressDataModel address3 = new AddressDataModel(3, "Lincoln", "Nebraska", "68516", "9876 Pine Lake Road");
            DepotDataModel depot1 = new DepotDataModel(1, address3);

            AddressDataModel address4 = new AddressDataModel(4, "Lincoln", "Nebraska", "68505", "8020 Holdrege Street");
            DepotDataModel depot2 = new DepotDataModel(2, address4);

            List<DepotDataModel> expectedDepotList = new List<DepotDataModel>();
            expectedDepotList.Add(depot1);
            expectedDepotList.Add(depot2);

            List<DepotDataModel> actualDepotList = DepotAccessor.GetDepotList();
            CollectionAssert.AreEquivalent(actualDepotList, expectedDepotList);
        }
    }
}
