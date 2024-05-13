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
            AddressAccessor accessor =
                new AddressAccessor(
                    "Server=localhost,1433;Database=master;User Id=SA;Password=MyStrongPassword123;Integrated Security=False;");
            
            
            Coordinate coord = new Coordinate(40.81338, -96.65949);
            AddressDataModel expectedAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street", coord);

            AddressDataModel actualAddress = accessor.GetAddress(1);

            Assert.AreEqual(expectedAddress, actualAddress);
        }

        [TestMethod]
        public void InvalidGetAddress_ReturnsNull()
        {
            AddressAccessor accessor =
                new AddressAccessor(
                    "Server=localhost,1433;Database=master;User Id=SA;Password=MyStrongPassword123;Integrated Security=False;");
            AddressDataModel invalidAddress = accessor.GetAddress(-1);
            Assert.IsNull(invalidAddress);
        }

        [TestMethod]
        public void ValidInsertAddress_ReturnsCorrectAddressId()
        {
            int expectedAddressId = 17;
            
            AddressAccessor accessor =
                new AddressAccessor(
                    "Server=localhost,1433;Database=master;User Id=SA;Password=MyStrongPassword123;Integrated Security=False;");

            Coordinate coord = new Coordinate(40.828411, -96.929764);
            AddressDataModel address = new AddressDataModel(null, "Pleasant Dale", "Nebraska", "68423", "2468 North 10th Road", coord);
            int actualAddressId = accessor.InsertAddress(address).Result;

            Assert.AreEqual(expectedAddressId, actualAddressId);
        }
    }
}
