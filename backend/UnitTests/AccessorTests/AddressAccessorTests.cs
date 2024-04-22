using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Accessors.DBModels;
using Accessors.ConnectionAccessor;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class AddressAccessorTests
    {
        [TestMethod]
        public void LoadAllAddressesFromDb_ReturnsExpectedList()
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
        public void LoadOneAddressFromDbUsingId_ReturnsCorrectAddress()
        {
            AddressDataModel expectedAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street");

            AddressDataModel actualAddress = AddressAccessor.GetAddress(1);

            Assert.AreEqual(expectedAddress, actualAddress);
        }
    }
}
