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
            AddressDataModel accountAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street");
            AccountDataModel account = new AccountDataModel(1, "Alfred", "Van Arsdall", "avanarsdall0@cocolog-nifty.com", "uI7lq}{e0WU", accountAddress, true);
            AddressDataModel shippedFrom = accountAddress;
            AddressDataModel shippedTo = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street");
            OrderDataModel expectedOrder = new OrderDataModel(1, "4829170638572946", shipDate, deliveryDate, account, shippedFrom, shippedTo);

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
            AddressDataModel accountAddress = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street");
            AccountDataModel account = new AccountDataModel(2, "Beltran", "Lillie", "blillie1@imdb.com", "hC7S>lx+N7a(?2>k", accountAddress, false);
            AddressDataModel shippedFrom = accountAddress;
            AddressDataModel shippedTo = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street");
            OrderDataModel expectedOrder = new OrderDataModel(2, "7294061538206194", shipDate, deliveryDate, account, shippedFrom, shippedTo);

            OrderDataModel actualOrder = OrderAccessor.GetOrderWithPackageId("7294061538206194");
            Assert.AreEqual(expectedOrder, actualOrder);
        }

        [TestMethod]
        public void InvalidGetOrderWithPackageId()
        {
            OrderDataModel invalidOrder = OrderAccessor.GetOrderWithPackageId("invalidId");
            Assert.IsNull(invalidOrder);
        }

        [TestMethod]
        public void NullGetOrderWithPackageId()
        {
            OrderDataModel nullOrder = OrderAccessor.GetOrderWithPackageId(null);
            Assert.IsNull(nullOrder);
        }
    }

    [TestClass]
    public class GetOrderListWithEmailAccessorTests
    {
        [TestMethod]
        public void ValidGetOrderListWithEmail()
        {
            DateTime shipDate = new DateTime(2024, 04, 14, 10, 30, 0, 0);
            DateTime deliveryDate = new DateTime(2024, 04, 17, 15, 44, 0, 0);
            AddressDataModel accountAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street");
            AccountDataModel account = new AccountDataModel(1, "Alfred", "Van Arsdall", "avanarsdall0@cocolog-nifty.com", "uI7lq}{e0WU", accountAddress, true);
            AddressDataModel shippedFrom = accountAddress;
            AddressDataModel shippedTo = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street");
            OrderDataModel order1 = new OrderDataModel(1, "4829170638572946", shipDate, deliveryDate, account, shippedFrom, shippedTo);

            DateTime shipDate2 = new DateTime(2024, 04, 15, 19, 33, 0, 0);
            DateTime deliveryDate2 = new DateTime(2024, 04, 18, 09, 17, 0, 0);
            OrderDataModel order2 = new OrderDataModel(3, "7632987401568235", shipDate2, deliveryDate2, account, shippedFrom, shippedTo);

            List<OrderDataModel> expectedOrderList = new List<OrderDataModel>();
            expectedOrderList.Add(order1);
            expectedOrderList.Add(order2);

            List<OrderDataModel> actualOrderList = OrderAccessor.GetOrderListWithEmail("avanarsdall0@cocolog-nifty.com");
            CollectionAssert.AreEquivalent(expectedOrderList, actualOrderList);
        }
    }

    [TestClass]
    public class GetOrderListWithAccountIdTests()
    {
        [TestMethod]
        public void ValidGetOrderListWithAccountId()
        {
            DateTime shipDate = new DateTime(2024, 04, 14, 10, 30, 0, 0);
            DateTime deliveryDate = new DateTime(2024, 04, 17, 15, 44, 0, 0);
            AddressDataModel accountAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street");
            AccountDataModel account = new AccountDataModel(1, "Alfred", "Van Arsdall", "avanarsdall0@cocolog-nifty.com", "uI7lq}{e0WU", accountAddress, true);
            AddressDataModel shippedFrom = accountAddress;
            AddressDataModel shippedTo = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street");
            OrderDataModel order1 = new OrderDataModel(1, "4829170638572946", shipDate, deliveryDate, account, shippedFrom, shippedTo);

            DateTime shipDate2 = new DateTime(2024, 04, 15, 19, 33, 0, 0);
            DateTime deliveryDate2 = new DateTime(2024, 04, 18, 09, 17, 0, 0);
            OrderDataModel order2 = new OrderDataModel(3, "7632987401568235", shipDate2, deliveryDate2, account, shippedFrom, shippedTo);

            List<OrderDataModel> expectedOrderList = new List<OrderDataModel>();
            expectedOrderList.Add(order1);
            expectedOrderList.Add(order2);

            List<OrderDataModel> actualOrderList = OrderAccessor.GetOrderListWithAccountId(1);
            CollectionAssert.AreEquivalent(expectedOrderList, actualOrderList);
        }
    }

    [TestClass]
    public class InsertOrderTests
    {
        [TestMethod]
        public void ValidInsertOrder()
        {
            int expectedOrderId = 4;

            DateTime deliveryDate = new DateTime(2024, 05, 01, 10, 14, 0, 0);
            int actualOrderId = OrderAccessor.InsertOrder("blillie1@imdb.com", deliveryDate, "Lincoln", "Nebraska", "68521", "2468 North 27th Street",
                "Lincoln", "Nebraska", "68516", "9876 Pine Lake Road");

            Assert.AreEqual(expectedOrderId, actualOrderId);
        }
    }
}
