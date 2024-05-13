using Accessors.Account;
using Accessors.Address;
using Accessors.Address.Models;
using Accessors.Order;
using Accessors.Order.Models;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class GetOrderWithOrderIdAccessorTests
    {
        [TestMethod]
        public void ValidGetOrderWithOrderId()
        {
            string connection =
                "Server=localhost,1433;Database=master;User Id=SA;Password=MyStrongPassword123;Integrated Security=False;";
            AddressAccessor addressAccessor =
                new AddressAccessor(
                    connection);
            AccountAccessor account = new AccountAccessor(connection, addressAccessor);
            OrderAccessor orderAccessor = new OrderAccessor(connection, account, addressAccessor);
            
            DateTime shipDate = new DateTime(2024, 04, 14, 10, 30, 0, 0);
            DateTime deliveryDate = new DateTime(2024, 04, 17, 15, 44, 0, 0);
            Coordinate coord = new Coordinate(40.81338, -96.65949);
            AddressDataModel shippedFrom = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street", coord);
            Coordinate coord2 = new Coordinate(40.83762, -96.68203);
            AddressDataModel shippedTo = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street", coord2);
            OrderDataModel expectedOrder = new OrderDataModel(1, "4829170638572946", shipDate, deliveryDate, 1, shippedFrom, shippedTo, "Delivered");
            
            OrderDataModel actualOrder = orderAccessor.GetOrderWithOrderId(1);
            Assert.AreEqual(expectedOrder, actualOrder);
        }

        [TestMethod]
        public void InvalidGetOrderWithOrderId()
        {
            string connection =
                "Server=localhost,1433;Database=master;User Id=SA;Password=MyStrongPassword123;Integrated Security=False;";
            AddressAccessor addressAccessor =
                new AddressAccessor(
                    connection);
            AccountAccessor account = new AccountAccessor(connection, addressAccessor);
            OrderAccessor orderAccessor = new OrderAccessor(connection, account, addressAccessor);
            
            OrderDataModel invalidOrder = orderAccessor.GetOrderWithOrderId(-1);
            Assert.IsNull(invalidOrder);
        }
    }

    [TestClass]
    public class GetOrderWithPackageIdAccessorTests
    {
        [TestMethod]
        public void ValidGetOrderWithPackageId()
        {
            string connection =
                "Server=localhost,1433;Database=master;User Id=SA;Password=MyStrongPassword123;Integrated Security=False;";
            AddressAccessor addressAccessor =
                new AddressAccessor(
                    connection);
            AccountAccessor account = new AccountAccessor(connection, addressAccessor);
            OrderAccessor orderAccessor = new OrderAccessor(connection, account, addressAccessor);
            
            DateTime shipDate = new DateTime(2024, 04, 01, 17, 12, 0, 0);
            DateTime deliveryDate = new DateTime(2024, 04, 05, 08, 15, 0, 0);
            Coordinate coord = new Coordinate(40.83762, -96.68203);
            AddressDataModel shippedFrom = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street", coord);
            Coordinate coord2 = new Coordinate(40.81338, -96.65949);
            AddressDataModel shippedTo = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street", coord2);
            OrderDataModel expectedOrder = new OrderDataModel(2, "7294061538206194", shipDate, deliveryDate, 2, shippedFrom, shippedTo, "Delivered");

            OrderDataModel actualOrder = orderAccessor.GetOrderWithPackageId("7294061538206194");
            Assert.AreEqual(expectedOrder, actualOrder);
        }

        [TestMethod]
        public void InvalidGetOrderWithPackageId()
        {
            string connection =
                "Server=localhost,1433;Database=master;User Id=SA;Password=MyStrongPassword123;Integrated Security=False;";
            AddressAccessor addressAccessor =
                new AddressAccessor(
                    connection);
            AccountAccessor account = new AccountAccessor(connection, addressAccessor);
            OrderAccessor orderAccessor = new OrderAccessor(connection, account, addressAccessor);
            
            OrderDataModel invalidOrder = orderAccessor.GetOrderWithPackageId("invalidId");
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
            
            string connection =
                "Server=localhost,1433;Database=master;User Id=SA;Password=MyStrongPassword123;Integrated Security=False;";
            AddressAccessor addressAccessor =
                new AddressAccessor(
                    connection);
            AccountAccessor account = new AccountAccessor(connection, addressAccessor);
            OrderAccessor orderAccessor = new OrderAccessor(connection, account, addressAccessor);

            DateTime deliveryDate = new DateTime(2024, 05, 07, 10, 14, 0, 0);
            Coordinate coord = new Coordinate(40.83762, -96.68203);
            AddressDataModel shippedFrom = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street", coord);
            Coordinate coord2 = new Coordinate(40.74076, -96.5849);
            AddressDataModel shippedTo = new AddressDataModel(3, "Lincoln", "Nebraska", "68516", "9876 Pine Lake Road", coord2);
            OrderDataModel order = new OrderDataModel(null, null, DateTime.Now, deliveryDate, 2, shippedFrom, shippedTo, "");

            int actualOrderId = orderAccessor.InsertOrder(order).Result;

            Assert.AreEqual(expectedOrderId, actualOrderId);
        }
    }
}
