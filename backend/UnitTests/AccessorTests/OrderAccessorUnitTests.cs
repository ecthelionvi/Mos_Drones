using Accessors.Accessors;
using Accessors.DBModels;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class GetOrderWithOrderIdAccessorTests
    {
        [TestMethod]
        public void ValidGetOrderWithOrderId()
        {
            DateTime shipDate = new DateTime(2024, 04, 14, 10, 30, 0, 0);
            DateTime deliveryDate = new DateTime(2024, 04, 17, 15, 44, 0, 0);
            Coordinate coord = new Coordinate(40.81338, -96.65949);
            AddressDataModel shippedFrom = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street", coord);
            Coordinate coord2 = new Coordinate(40.83762, -96.68203);
            AddressDataModel shippedTo = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street", coord2);
            OrderDataModel expectedOrder = new OrderDataModel(1, "4829170638572946", shipDate, deliveryDate, 1, shippedFrom, shippedTo, "Delivered");

            OrderDataModel actualOrder = OrderAccessor.GetOrderWithOrderId(1);
            Assert.AreEqual(expectedOrder, actualOrder);
        }

        [TestMethod]
        public void InvalidGetOrderWithOrderId()
        {
            OrderDataModel invalidOrder = OrderAccessor.GetOrderWithOrderId(-1);
            Assert.IsNull(invalidOrder);
        }
    }

    [TestClass]
    public class GetOrderWithPackageIdAccessorTests
    {
        [TestMethod]
        public void ValidGetOrderWithPackageId()
        {
            DateTime shipDate = new DateTime(2024, 04, 01, 17, 12, 0, 0);
            DateTime deliveryDate = new DateTime(2024, 04, 05, 08, 15, 0, 0);
            Coordinate coord = new Coordinate(40.83762, -96.68203);
            AddressDataModel shippedFrom = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street", coord);
            Coordinate coord2 = new Coordinate(40.81338, -96.65949);
            AddressDataModel shippedTo = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street", coord2);
            OrderDataModel expectedOrder = new OrderDataModel(2, "7294061538206194", shipDate, deliveryDate, 2, shippedFrom, shippedTo, "Delivered");

            OrderDataModel actualOrder = OrderAccessor.GetOrderWithPackageId("7294061538206194");
            Assert.AreEqual(expectedOrder, actualOrder);
        }

        [TestMethod]
        public void InvalidGetOrderWithPackageId()
        {
            OrderDataModel invalidOrder = OrderAccessor.GetOrderWithPackageId("invalidId");
            Assert.IsNull(invalidOrder);
        }
    }

    [TestClass]
    public class InsertOrderTests
    {
        [TestMethod]
        public void ValidInsertOrder()
        {
            int expectedOrderId = 4;

            DateTime deliveryDate = new DateTime(2024, 05, 07, 10, 14, 0, 0);
            Coordinate coord = new Coordinate(40.83762, -96.68203);
            AddressDataModel shippedFrom = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street", coord);
            Coordinate coord2 = new Coordinate(40.74076, -96.5849);
            AddressDataModel shippedTo = new AddressDataModel(3, "Lincoln", "Nebraska", "68516", "9876 Pine Lake Road", coord2);
            OrderDataModel order = new OrderDataModel(null, null, DateTime.Now, deliveryDate, 2, shippedFrom, shippedTo, "");

            int actualOrderId = OrderAccessor.InsertOrder(order);

            Assert.AreEqual(expectedOrderId, actualOrderId);
        }
    }
}
