using Accessors.Address;
using Accessors.Address.Models;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class AddressAccessorTests
    {
        [TestMethod]
        public void ValidGetAddress_ReturnsCorrectAddress()
        {
            Coordinate coord = new Coordinate(40.81338, -96.65949);
            AddressDataModel expectedAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street", coord);

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
            int expectedAddressId = 17;

            Coordinate coord = new Coordinate(40.828411, -96.929764);
            AddressDataModel address = new AddressDataModel(null, "Pleasant Dale", "Nebraska", "68423", "2468 North 10th Road", coord);
            AddressAccessor addressAccessor = new AddressAccessor();
            int actualAddressId = addressAccessor.InsertAddress(address).Result;

            Assert.AreEqual(expectedAddressId, actualAddressId);
        }
    }
}
