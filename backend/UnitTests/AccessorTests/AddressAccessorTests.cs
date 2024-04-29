using Accessors.DBModels;
using Accessors.Accessors;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class AddressAccessorTests
    {
        [TestMethod]
        public void ValidGetAddressList_ReturnsExpectedList()
        {
            List<AddressDataModel> expectedAddressList = new List<AddressDataModel>();
            AddressDataModel a = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street");
            AddressDataModel b = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street");
            AddressDataModel c = new AddressDataModel(3, "Lincoln", "Nebraska", "68516", "9876 Pine Lake Road");
            AddressDataModel d = new AddressDataModel(4, "Lincoln", "Nebraska", "68505", "8020 Holdrege Street");
            AddressDataModel e = new AddressDataModel(5, "Lincoln", "Nebraska", "68506", "1357 South 84th Street");

            expectedAddressList.Add(a);
            expectedAddressList.Add(b);
            expectedAddressList.Add(c);
            expectedAddressList.Add(d);
            expectedAddressList.Add(e);

            List<AddressDataModel> actualAddressList = AddressAccessor.GetAddressList();
            CollectionAssert.AreEquivalent(expectedAddressList, actualAddressList);
        }

        [TestMethod]
        public void ValidGetAddress_ReturnsCorrectAddress()
        {
            AddressDataModel expectedAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street");

            AddressDataModel actualAddress = AddressAccessor.GetAddress(1);

            Assert.AreEqual(expectedAddress, actualAddress);
        }

        [TestMethod]
        public void InvalidGetAddress_ReturnsNull()
        {
            AddressDataModel invalidAddress = AddressAccessor.GetAddress(-1);
            Assert.IsNull(invalidAddress);
        }

        [TestMethod]
        public void ValidInsertAddress_ReturnsCorrectAddressId()
        {
            int expectedAddressId = 6;

            int actualAddressId = AddressAccessor.InsertAddress("Pleasant Dale", "Nebraska", "68423", "2468 North 10th Road");

            Assert.AreEqual(expectedAddressId, actualAddressId);
        }
    }
}
